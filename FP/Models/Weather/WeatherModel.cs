using Newtonsoft.Json;

namespace FP.Models.Weather
{
    public class WeatherModel
    {
        #region  Properties

        [JsonProperty("temperature")] public string Temperature { get; set; }

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("humidity")] public string Humidity { get; set; }

        #endregion
    }
}