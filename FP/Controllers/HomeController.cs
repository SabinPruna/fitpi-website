using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FP.Factory;
using FP.Models;
using FP.Models.Fitbit;
using FP.Models.Weather;
using FP.ViewModels;

namespace FP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string date = null)
        {
            MainModel model = new MainModel();

            if (null == date)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(date);
                dateTime = dateTime.AddDays(1);
                date = dateTime.ToString("yyyy-MM-dd");
            }

            StatsModel stats = Task.Run(() => ApiClientFactory.Instance.GetStats(date)).Result;
            List<WeatherModel> weathers = Task.Run(() => ApiClientFactory.Instance.GetRoomWeather()).Result;

            model.Stats = stats;
            model.Weather = new WeatherViewModel();
            model.Weather.RoomWeathers = weathers;

            OpenWeatherSingleRecordModel todayWeather = Task.Run(() => ApiClientFactory.Instance.GetTodayWeather()).Result;
            OpenWeatherForecastModel forecastWeather = Task.Run(() => ApiClientFactory.Instance.GetForecastWeather()).Result;

            model.Weather.ForecastWeather = forecastWeather;
            model.Weather.TodayWeather = todayWeather;

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
            List<WeigthModel> weigths = Task.Run(() => ApiClientFactory.Instance.GetWeight()).Result;
            ;
            weigths = weigths.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> weigthData = new List<object>();

            foreach (WeigthModel weightsModel in weigths)
            {
                datesData.Add(weightsModel.Date);
                weigthData.Add(weightsModel.StartWeight);
            }

            jsonData.Add(datesData);
            jsonData.Add(weigthData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

    }
}