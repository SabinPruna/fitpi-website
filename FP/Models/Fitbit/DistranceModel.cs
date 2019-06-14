using System.Collections.Generic;
using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public class DistanceModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("summary")] public DistanceSummary Summary { get; set; }

        #endregion
    }

    public class DistanceSummary
    {
        #region  Properties

        [JsonProperty("distances")] public List<DistanceWithActivity> Distances { get; set; }

        #endregion
    }

    public class DistanceWithActivity
    {
        #region  Properties

        [JsonProperty("activity")] public string Activity { get; set; }

        [JsonProperty("distance")] public double DistanceDistance { get; set; }

        #endregion
    }
}