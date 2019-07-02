using Newtonsoft.Json;

namespace FP.Models.Worklog
{
    public class WorklogModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("duration")] public string Duration { get; set; }

        [JsonProperty("end")] public string End { get; set; }

        [JsonProperty("month")] public string Month { get; set; }

        [JsonProperty("start")] public string Start { get; set; }

        #endregion
    }
}