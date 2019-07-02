using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FP.Factory;
using FP.Models;
using FP.Models.Fitbit;
using FP.Models.Timetable;
using FP.Models.Weather;
using FP.Models.Worklog;
using FP.ViewModels;

namespace FP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string date = null)
        {
            MainModel model = new MainModel();
            string month = string.Empty;
            string startOfWeek = string.Empty;

            if (null == date)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
                month = DateTime.Now.ToString("yyyy-MM");
            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(date);
                dateTime = dateTime.AddDays(1);
                date = dateTime.ToString("yyyy-MM-dd");
                month = dateTime.ToString("yyyy-MM");
            }

            StatsModel stats = Task.Run(() => ApiClientFactory.Instance.GetStats(date)).Result;
            List<WeatherModel> weathers = Task.Run(() => ApiClientFactory.Instance.GetRoomWeather()).Result;

            model.Stats = stats;
            model.Weather = new WeatherViewModel();
            model.Weather.RoomWeathers = weathers;

            OpenWeatherSingleRecordModel todayWeather =
                Task.Run(() => ApiClientFactory.Instance.GetTodayWeather()).Result;
            OpenWeatherForecastModel forecastWeather =
                Task.Run(() => ApiClientFactory.Instance.GetForecastWeather()).Result;

            model.Weather.ForecastWeather = forecastWeather;
            model.Weather.TodayWeather = todayWeather;

            startOfWeek = DateTime.Today.AddDays(-(int) DateTime.Today.DayOfWeek + (int) DayOfWeek.Monday)
                .ToString("yyyy-MM-dd");
            string endOfWeek = DateTime.Today.AddDays(-(int) DateTime.Today.DayOfWeek + (int) DayOfWeek.Monday)
                .AddDays(6)
                .ToString("yyyy-MM-dd");

            model.Worklog = new WorklogViewModel();
            model.Worklog.Worklogs = Task.Run(() => ApiClientFactory.Instance.GetWorklog()).Result;
            model.Worklog.WeeklyQuota = GetWeeklyQuotaFromWorklogs(model.Worklog.Worklogs, startOfWeek, endOfWeek);
            model.Worklog.MonthlyQuota = GetMonthlyQuotaFromWorklogs(model.Worklog.Worklogs, month);


            return View("Index", model);
        }

      

        [HttpPost]
        public ActionResult Index(StatsModel model)
        {
            string date = model.Date;
            StatsModel previousStats = Task.Run(() => ApiClientFactory.Instance.GetStats(date)).Result;

            previousStats.Summary.CaloriesOut = model.Summary.CaloriesOut;
            previousStats.Summary.Steps = model.Summary.Steps;
            previousStats.Summary.LightlyActiveMinutes = model.Summary.LightlyActiveMinutes;
            previousStats.Summary.Distances[0].DistanceDistance = model.Summary.Distances[0].DistanceDistance;
            previousStats.SleepMinutes = model.SleepMinutes;
            previousStats.Summary.Floors = model.Summary.Floors;
            previousStats.StartWeight = model.StartWeight;

            Task.Run(() => ApiClientFactory.Instance.SaveStats(previousStats));


            return View("Index", previousStats);
        }

        public async Task<ActionResult> Tweet(string date = null)
        {
            if (null == date)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }

            StatsModel stats = Task.Run(() => ApiClientFactory.Instance.GetStats(date)).Result;

            string message =
                $"Steps: {stats.Summary.Steps}, Cals:{stats.Summary.CaloriesOut}, Distance:{stats.Summary.Distances[0].DistanceDistance}, Sleep: {stats.SleepMinutes}, Floors: {stats.Summary.Floors}, Weight: {stats.StartWeight}, Active: {stats.Summary.LightlyActiveMinutes}";

            string result = await ApiClientFactory.Instance.PostTwitter(message);

            return View("Index");
        }

        [HttpGet]
        public JsonResult TimetableJson()
        {
            List<Course> courses = Task.Run(() => ApiClientFactory.Instance.GetTimetable()).Result;

            List<object> jsonData = new List<object>();

            Dictionary<string, object> courseJson = new Dictionary<string, object>();

            List<Course> myCourses = courses.Where(c => c.Group == "10LF 262" && c.WeekType == "Odd").ToList();


            foreach (Course course in myCourses)
            {
                courseJson = new Dictionary<string, object>();
                courseJson["title"] = course.Name;
                courseJson["location"] = course.Location;
                courseJson["teacher"] = course.Teacher;
                courseJson["coursetype"] = course.CourseType;
                courseJson["allDay"] = false;
                courseJson["daysOfWeek"] = course.Day;
                courseJson["start"] = course.Hours.Split('-')[0].Replace(",", ":");
                courseJson["startTime"] = course.Hours.Split('-')[0].Replace(",", ":");

                courseJson["startHour"] = course.Hours.Split('-')[0].Replace(",", ":").Split(':')[0];
                courseJson["startMinute"] = course.Hours.Split('-')[0].Replace(",", ":").Split(':')[1];

                courseJson["endHour"] = course.Hours.Split('-')[1].Replace(",", ":").Split(':')[0];
                courseJson["endMinute"] = course.Hours.Split('-')[1].Replace(",", ":").Split(':')[1];
                jsonData.Add(courseJson);
            }


            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult WorklogJson()
        {
            List<WorklogModel> logs = Task.Run(() => ApiClientFactory.Instance.GetWorklog()).Result;
            logs = logs.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> durationData = new List<object>();

            foreach (WorklogModel log in logs)
            {
                datesData.Add(log.Date);
                durationData.Add(float.Parse(log.Duration.Replace("m", "").Replace("h", ".").TrimEnd('.')));
            }

            jsonData.Add(datesData);
            jsonData.Add(durationData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Worklog(WorklogViewModel model)
        {
            var logs = model.Worklogs;

            foreach (WorklogModel worklogModel in logs)
            {
                Task.Run(() => ApiClientFactory.Instance.SaveWorklog(worklogModel));
            }



            return new EmptyResult();
        }



        private int GetWeeklyQuotaFromWorklogs(List<WorklogModel> worklogWorklogs, string startOfWeek, string endOfWeek)
        {
            int result = 0;

            List<WorklogModel> logs = worklogWorklogs.Where(l =>
                int.Parse(l.Date.Replace("-", "")) >= int.Parse(startOfWeek.Replace("-", "")) &&
                int.Parse(l.Date.Replace("-", "")) <= int.Parse(endOfWeek.Replace("-", ""))).ToList();


            foreach (WorklogModel worklogModel in logs)
            {
                DateTime start = new DateTime(2019, 01, 01, int.Parse(worklogModel.Start.Split(':')[0]),
                    int.Parse(worklogModel.Start.Split(':')[1]), 00);
                DateTime end = new DateTime(2019, 01, 01, int.Parse(worklogModel.End.Split(':')[0]),
                    int.Parse(worklogModel.End.Split(':')[1]), 00);

                result += (end - start).Duration().Hours;
            }

            return result;
        }

        private int GetMonthlyQuotaFromWorklogs(List<WorklogModel> worklogWorklogs, string month)
        {
            int result = 0;

            List<WorklogModel> logs = worklogWorklogs
                .Where(l => int.Parse(l.Month.Replace("-", "")) == int.Parse(month.Replace("-", ""))).ToList();


            foreach (WorklogModel worklogModel in logs)
            {
                DateTime start = new DateTime(2019, 01, 01, int.Parse(worklogModel.Start.Split(':')[0]),
                    int.Parse(worklogModel.Start.Split(':')[1]), 00);
                DateTime end = new DateTime(2019, 01, 01, int.Parse(worklogModel.End.Split(':')[0]),
                    int.Parse(worklogModel.End.Split(':')[1]), 00);

                result += (end - start).Duration().Hours;
            }

            return result;
        }

        [HttpPost]
        public ActionResult AddWorklog(WorklogModel model)
        {
            
            if (ModelState.IsValid)
            {
                model.Month = model.Date.Substring(0, model.Date.Length - 3);
                DateTime start = new DateTime(2019, 01, 01, int.Parse(model.Start.Split(':')[0]),
                    int.Parse(model.Start.Split(':')[1]), 00);
                DateTime end = new DateTime(2019, 01, 01, int.Parse(model.End.Split(':')[0]),
                    int.Parse(model.End.Split(':')[1]), 00);

                model.Duration = (end - start).ToString(@"h\hmm\m");

                if (model.Duration.Contains("00"))
                {
                    model.Duration = model.Duration.Substring(0, model.Duration.Length - 3);
                }

                Task.Run(() => ApiClientFactory.Instance.SaveWorklog(model));

                return RedirectToAction("Index");
            }

            return PartialView("Partials/AddWorklog", model);
        }
    }
}