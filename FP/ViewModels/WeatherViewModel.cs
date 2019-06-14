using System.Collections.Generic;
using FP.Models.Weather;

namespace FP.ViewModels
{
    public class WeatherViewModel
    {
        #region  Properties

        public List<WeatherModel> RoomWeathers { get; set; }

        public OpenWeatherSingleRecordModel TodayWeather { get; set; }

        public OpenWeatherForecastModel ForecastWeather { get; set; }

        #endregion
    }
}