using System;
using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public class CaloriesModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("summary")] public SummaryCalories Summary { get; set; }

        #endregion
    }

    public class SummaryCalories
    {
        #region  Properties

        [JsonProperty("caloriesOut")] public long CaloriesOut { get; set; }

        #endregion
    }
}