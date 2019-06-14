using Newtonsoft.Json;

namespace FP.Models.Timetable
{
    public class Course
    {
        #region  Properties

        [JsonProperty("Year")] public long Year { get; set; }

        [JsonProperty("Specialisation")] public string Specialisation { get; set; }

        [JsonProperty("Group")] public string Group { get; set; }

        [JsonProperty("SemiGroup")] public string SemiGroup { get; set; }

        [JsonProperty("Name")] public string Name { get; set; }

        [JsonProperty("Type")] public string CourseType { get; set; }

        [JsonProperty("Location")] public string Location { get; set; }

        [JsonProperty("Teacher")] public string Teacher { get; set; }

        [JsonProperty("Day")] public long Day { get; set; }

        [JsonProperty("Hours")] public string Hours { get; set; }

        [JsonProperty("WeekType")] public string WeekType { get; set; }

        #endregion
    }
}