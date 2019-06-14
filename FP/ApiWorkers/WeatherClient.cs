using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FP.Models.Fitbit;
using FP.Models.Weather;

namespace FP.ApiWorkers
{
    public partial class ApiClient
    {
        public async Task<List<WeatherModel>> GetRoomWeather()
        {
            Uri requestUrl = CreateWeatherRequestUri(string.Format(CultureInfo.InvariantCulture, string.Empty));
            return await GetAsync<List<WeatherModel>>(requestUrl);
        }

        public async Task<OpenWeatherSingleRecordModel> GetTodayWeather()
        {
            Uri requestUrl = CreateOpenWeatherRequestUri(string.Empty, "action=weather");
            return await GetAsync<OpenWeatherSingleRecordModel>(requestUrl);
        }

        public async Task<OpenWeatherForecastModel> GetForecastWeather()
        {
            Uri requestUrl = CreateOpenWeatherRequestUri(string.Empty, "action=");
            return await GetAsync<OpenWeatherForecastModel>(requestUrl);
        }
    }
}