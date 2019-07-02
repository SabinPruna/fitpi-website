using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FP.Models.Fitbit;
using FP.ViewModels;

namespace FP.Models
{
    public class MainModel
    {
        public StatsModel Stats { get; set; }

        public WeatherViewModel Weather { get; set; }

        public WorklogViewModel Worklog { get; set; }
    }
}