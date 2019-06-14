using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public class StepsModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("summary")] public StepsSummary Summary { get; set; }

        #endregion
    }

    public class StepsSummary
    {
        #region  Properties

        [JsonProperty("steps")] public long Steps { get; set; }

        #endregion
    }
}