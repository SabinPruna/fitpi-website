using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FP.Models.Fitbit
{
    public partial class WeigthModel
    {
        #region  Properties

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("startWeight")] public double StartWeight { get; set; }

        [JsonProperty("weight")] public long Weight { get; set; }

        #endregion
    }

}