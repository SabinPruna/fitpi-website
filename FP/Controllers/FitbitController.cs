using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FP.Factory;
using FP.Models.Fitbit;

namespace FP.Controllers
{
    public class FitbitController : Controller
    {
        // GET: Fitbit
        [HttpGet]
        public ActionResult Calories()
        {
            List<CaloriesModel> calories = Task.Run(() => ApiClientFactory.Instance.GetCalories()).Result;
            ;
            calories = calories.OrderByDescending(c => c.Date).ToList();

            return View("Calories", calories);
        }

        [HttpGet]
        public JsonResult CaloriesJson()
        {
            List<CaloriesModel> calories = Task.Run(() => ApiClientFactory.Instance.GetCalories()).Result;
            ;
            calories = calories.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> caloriesData = new List<object>();

            foreach (CaloriesModel caloriesModel in calories)
            {
                datesData.Add(caloriesModel.Date);
                caloriesData.Add(caloriesModel.Summary.CaloriesOut);
            }

            jsonData.Add(datesData);
            jsonData.Add(caloriesData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Calories(List<CaloriesModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveCalories(models));

            return View("Calories", models);
        }

        [HttpGet]
        public ActionResult ActiveMinutes()
        {
            List<ActiveMinutesModel> minutes = Task.Run(() => ApiClientFactory.Instance.GetMinutes()).Result;
            ;
            minutes = minutes.OrderByDescending(c => c.Date).ToList();

            return View("Minutes", minutes);
        }

        [HttpGet]
        public JsonResult ActiveMinutesJson()
        {
            List<ActiveMinutesModel> minutes = Task.Run(() => ApiClientFactory.Instance.GetMinutes()).Result;
            ;
            minutes = minutes.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> minutesData = new List<object>();

            foreach (ActiveMinutesModel minutesModel in minutes)
            {
                datesData.Add(minutesModel.Date);
                minutesData.Add(minutesModel.Summary.LightlyActiveMinutes);
            }

            jsonData.Add(datesData);
            jsonData.Add(minutesData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ActiveMinutes(List<ActiveMinutesModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveMinutes(models));

            return View("Minutes", models);
        }


        [HttpGet]
        public ActionResult Distance()
        {
            List<DistanceModel> distances = Task.Run(() => ApiClientFactory.Instance.GetDistance()).Result;
            ;
            distances = distances.OrderByDescending(c => c.Date).ToList();

            return View("Distance", distances);
        }

        [HttpGet]
        public JsonResult DistanceJson()
        {
            List<DistanceModel> distances = Task.Run(() => ApiClientFactory.Instance.GetDistance()).Result;
            ;
            distances = distances.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> distancesData = new List<object>();

            foreach (DistanceModel distanceModel in distances)
            {
                datesData.Add(distanceModel.Date);
                distancesData.Add(distanceModel.Summary.Distances.First().DistanceDistance);
            }

            jsonData.Add(datesData);
            jsonData.Add(distancesData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Distance(List<DistanceModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveDistances(models));

            return View("Distance", models);
        }

        [HttpGet]
        public ActionResult Sleep()
        {
            List<SleepModel> sleep = Task.Run(() => ApiClientFactory.Instance.GetSleep()).Result;
            ;
            sleep = sleep.OrderByDescending(c => c.Date).ToList();

            return View("Sleep", sleep);
        }

        [HttpGet]
        public JsonResult SleepJson()
        {
            List<SleepModel> sleep = Task.Run(() => ApiClientFactory.Instance.GetSleep()).Result;
            ;
            sleep = sleep.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> sleepData = new List<object>();

            foreach (SleepModel sleepModel in sleep)
            {
                datesData.Add(sleepModel.Date);
                sleepData.Add(sleepModel.SleepMinutes);
            }

            jsonData.Add(datesData);
            jsonData.Add(sleepData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Sleep(List<SleepModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveSleep(models));

            return View("Sleep", models);
        }

        [HttpGet]
        public ActionResult Floors()
        {
            List<FloorsModel> floors = Task.Run(() => ApiClientFactory.Instance.GetFloors()).Result;
            ;
            floors = floors.OrderByDescending(c => c.Date).ToList();

            return View("Floors", floors);
        }

        [HttpGet]
        public JsonResult FloorsJson()
        {
            List<FloorsModel> floors = Task.Run(() => ApiClientFactory.Instance.GetFloors()).Result;
            ;
            floors = floors.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> floorsData = new List<object>();

            foreach (FloorsModel floorsModel in floors)
            {
                datesData.Add(floorsModel.Date);
                floorsData.Add(floorsModel.Summary.Floors);
            }

            jsonData.Add(datesData);
            jsonData.Add(floorsData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Floors(List<FloorsModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveFloors(models));

            return View("Floors", models);
        }


        [HttpGet]
        public ActionResult Weight()
        {
            List<WeigthModel> weights = Task.Run(() => ApiClientFactory.Instance.GetWeight()).Result;
            ;
            weights = weights.OrderByDescending(c => c.Date).ToList();

            return View("Weight", weights);
        }

        [HttpGet]
        public JsonResult WeightJson()
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

        [HttpPost]
        public ActionResult Weight(List<WeigthModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveWeigth(models));

            return View("Weight", models);
        }

        [HttpGet]
        public ActionResult Steps()
        {
            List<StepsModel> steps = Task.Run(() => ApiClientFactory.Instance.GetSteps()).Result;
            ;
            steps = steps.OrderByDescending(c => c.Date).ToList();

            return View("Steps", steps);
        }

        [HttpGet]
        public JsonResult StepsJson()
        {
            List<StepsModel> steps = Task.Run(() => ApiClientFactory.Instance.GetSteps()).Result;
            ;
            steps = steps.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> stepsData = new List<object>();

            foreach (StepsModel stepsModel in steps)
            {
                datesData.Add(stepsModel.Date);
                stepsData.Add(stepsModel.Summary.Steps);
            }

            jsonData.Add(datesData);
            jsonData.Add(stepsData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Steps(List<StepsModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveSteps(models));

            return View("Steps", models);
        }

        [HttpGet]
        public ActionResult HeartRate()
        {
            List<HeartRateModel> hr = Task.Run(() => ApiClientFactory.Instance.GetHeartRate()).Result;

            hr = hr.OrderByDescending(c => c.Date).ToList();
            foreach (HeartRateModel heartRateModel in hr)
            {
                if (heartRateModel.Summary.RestingHeartRate == null)
                {
                    heartRateModel.Summary.RestingHeartRate = 0;
                }
            }

            return View("HeartRate", hr);
        }

        [HttpGet]
        public JsonResult HeartRateJson()
        {
            List<HeartRateModel> heartRateModels = Task.Run(() => ApiClientFactory.Instance.GetHeartRate()).Result;
            ;
            heartRateModels = heartRateModels.OrderBy(c => c.Date).ToList();

            List<object> jsonData = new List<object>();
            List<object> datesData = new List<object>();
            List<object> hrData = new List<object>();

            foreach (HeartRateModel hrModel in heartRateModels)
            {
                datesData.Add(hrModel.Date);
                hrData.Add(hrModel.Summary.RestingHeartRate ?? 0);
            }

            jsonData.Add(datesData);
            jsonData.Add(hrData);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult HeartRate(List<HeartRateModel> models)
        {
            Task.Run(() => ApiClientFactory.Instance.SaveHeartRate(models));

            return View("HeartRate", models);
        }
    }
}

