using System.Collections.Generic;
using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public partial class ActiveMinutesModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("summary")] public AmSummary Summary { get; set; }

        #endregion
    }

    public class AmSummary
    {
        #region  Properties

        [JsonProperty("lightlyActiveMinutes")] public long LightlyActiveMinutes { get; set; }

        [JsonProperty("veryActiveMinutes")] public long VeryActiveMinutes { get; set; }

        #endregion
    }

    public partial class ActiveMinutesModel
    {
        public static List<ActiveMinutesModel> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<ActiveMinutesModel>>(json, Converter.Settings);
        }
    }
}