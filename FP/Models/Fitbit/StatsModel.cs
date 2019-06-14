using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FP.Models.Fitbit
{
    public partial class StatsModel
    {
        #region  Properties

        [JsonProperty("activities")] public List<Activity> Activities { get; set; }

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("goals")] public Goals Goals { get; set; }

        [JsonProperty("sleepGoalMinutes")] public long SleepGoalMinutes { get; set; }

        [JsonProperty("sleepMinutes")] public long SleepMinutes { get; set; }

        [JsonProperty("sleepMinutesAwake")] public long SleepMinutesAwake { get; set; }

        [JsonProperty("startWeight")] public double StartWeight { get; set; }

        [JsonProperty("summary")] public Summary Summary { get; set; }

        [JsonProperty("weight")] public long Weight { get; set; }

        #endregion
    }

    public class Activity
    {
        #region  Properties

        [JsonProperty("activityId")] public long ActivityId { get; set; }

        [JsonProperty("activityParentId")] public long ActivityParentId { get; set; }

        [JsonProperty("activityParentName")] public string ActivityParentName { get; set; }

        [JsonProperty("calories")] public long Calories { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("distance")] public long Distance { get; set; }

        [JsonProperty("duration")] public long Duration { get; set; }

        [JsonProperty("hasStartTime")] public bool HasStartTime { get; set; }

        [JsonProperty("isFavorite")] public bool IsFavorite { get; set; }

        [JsonProperty("lastModified")] public DateTimeOffset LastModified { get; set; }

        [JsonProperty("logId")] public long LogId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("startDate")] public DateTimeOffset StartDate { get; set; }

        [JsonProperty("startTime")] public string StartTime { get; set; }

        [JsonProperty("steps")] public long Steps { get; set; }

        #endregion
    }

    public class Goals
    {
        #region  Properties

        [JsonProperty("activeMinutes")] public long ActiveMinutes { get; set; }

        [JsonProperty("caloriesOut")] public long CaloriesOut { get; set; }

        [JsonProperty("distance")] public long Distance { get; set; }

        [JsonProperty("floors")] public long Floors { get; set; }

        [JsonProperty("steps")] public long Steps { get; set; }

        #endregion
    }

    public class Summary
    {
        #region  Properties

        [JsonProperty("activeScore")] public long ActiveScore { get; set; }

        [JsonProperty("activityCalories")] public long ActivityCalories { get; set; }

        [JsonProperty("caloriesBMR")] public long CaloriesBmr { get; set; }

        [JsonProperty("caloriesOut")] public long CaloriesOut { get; set; }

        [JsonProperty("distances")] public List<Distance> Distances { get; set; }

        [JsonProperty("elevation")] public long Elevation { get; set; }

        [JsonProperty("fairlyActiveMinutes")] public long FairlyActiveMinutes { get; set; }

        [JsonProperty("floors")] public long Floors { get; set; }

        [JsonProperty("heartRateZones")] public List<HeartRateZone> HeartRateZones { get; set; }

        [JsonProperty("lightlyActiveMinutes")] public long LightlyActiveMinutes { get; set; }

        [JsonProperty("marginalCalories")] public long MarginalCalories { get; set; }

        [JsonProperty("sedentaryMinutes")] public long SedentaryMinutes { get; set; }

        [JsonProperty("steps")] public long Steps { get; set; }

        [JsonProperty("veryActiveMinutes")] public long VeryActiveMinutes { get; set; }

        #endregion
    }

    public class Distance
    {
        #region  Properties

        [JsonProperty("activity")] public string Activity { get; set; }

        [JsonProperty("distance")] public double DistanceDistance { get; set; }

        #endregion
    }

    public class HeartRateZone
    {
        #region  Properties

        [JsonProperty("caloriesOut")] public double CaloriesOut { get; set; }

        [JsonProperty("max")] public long Max { get; set; }

        [JsonProperty("min")] public long Min { get; set; }

        [JsonProperty("minutes")] public long Minutes { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        #endregion
    }

    public partial class StatsModel
    {
        public static StatsModel FromJson(string json)
        {
            return JsonConvert.DeserializeObject<StatsModel>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this StatsModel self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }
}