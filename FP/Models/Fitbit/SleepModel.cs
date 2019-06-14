using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public class SleepModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("sleepMinutes")] public long SleepMinutes { get; set; }

        [JsonProperty("sleepMinutesAwake")] public long SleepMinutesAwake { get; set; }

        #endregion
    }
}