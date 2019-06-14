using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FP.Models.Fitbit;
using Newtonsoft.Json;

namespace FP.ViewModels
{
    public class StatsViewModel
    {
        [JsonProperty("activities")] public List<object> Activities { get; set; }

        [JsonProperty("date")] public DateTimeOffset Date { get; set; }

        [JsonProperty("goals")] public Goals Goals { get; set; }

        [JsonProperty("sleepGoalMinutes")] public long SleepGoalMinutes { get; set; }

        [JsonProperty("sleepMinutes")] public long SleepMinutes { get; set; }

        [JsonProperty("sleepMinutesAwake")] public long SleepMinutesAwake { get; set; }

        [JsonProperty("startWeight")] public double StartWeight { get; set; }

        [JsonProperty("summary")] public Summary Summary { get; set; }

        [JsonProperty("weight")] public long Weight { get; set; }
    }
}