using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public class FloorsModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("summary")] public FloorsSummary Summary { get; set; }

        #endregion
    }

    public class FloorsSummary
    {
        #region  Properties

        [JsonProperty("floors")] public long Floors { get; set; }

        #endregion
    }
}