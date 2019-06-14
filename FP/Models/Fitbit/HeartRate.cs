using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FP.Models.Fitbit
{
    public partial class HeartRateModel
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("summary")]
        public HrSummary Summary { get; set; }
    }

    public class HrSummary
    {
        [JsonProperty("restingHeartRate", NullValueHandling = NullValueHandling.Ignore)]
        public long? RestingHeartRate { get; set; }
    }
}