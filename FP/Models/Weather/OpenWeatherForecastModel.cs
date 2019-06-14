using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FP.Models.Weather
{
    public class OpenWeatherForecastModel
    {
        #region  Properties

        [JsonProperty("cod")] public long Cod { get; set; }

        [JsonProperty("message")] public double Message { get; set; }

        [JsonProperty("cnt")] public long Cnt { get; set; }

        [JsonProperty("list")] public List<WeatherList> WeatherListData { get; set; }

        [JsonProperty("city")] public City City { get; set; }

        #endregion
    }

    public class City
    {
        #region  Properties

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("coord")] public Coord Coord { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("timezone")] public long Timezone { get; set; }

        #endregion
    }


    public class WeatherList
    {
        #region  Properties

        [JsonProperty("dt")] public long Dt { get; set; }

        [JsonProperty("main")] public MainClass Main { get; set; }

        [JsonProperty("weather")] public List<WeatherEntry> Weather { get; set; }

        [JsonProperty("clouds")] public Clouds Clouds { get; set; }

        [JsonProperty("wind")] public Wind Wind { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [JsonProperty("sys")] public Sys Sys { get; set; }

        [JsonProperty("dt_txt")] public string DtTxt { get; set; }

        #endregion
    }


    public class WeatherEntry
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("main")] public string Main { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("icon")] public string Icon { get; set; }
    }

    public class MainClass
   {
        #region  Properties

        [JsonProperty("temp")] public double Temp { get; set; }

        [JsonProperty("temp_min")] public double TempMin { get; set; }

        [JsonProperty("temp_max")] public double TempMax { get; set; }

        [JsonProperty("pressure")] public double Pressure { get; set; }

        [JsonProperty("sea_level")] public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")] public double GrndLevel { get; set; }

        [JsonProperty("humidity")] public long Humidity { get; set; }

        [JsonProperty("temp_kf")] public double TempKf { get; set; }

        #endregion
    }

    public partial class Sys
    {
        #region  Properties

        [JsonProperty("pod")] public Pod Pod { get; set; }

        #endregion
    }

    public enum Pod
    {
        D,
        N
    }

    public enum MainEnum
    {
        Clear,
        Clouds,
        Rain
    }


}