using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FP.Models.Timetable;

namespace FP.ApiWorkers
{
    public partial class ApiClient
    {
        public async Task<List<Course>> GetTimetable()
        {
            Uri requestUrl = CreateTimetableRequestUri(string.Empty, $"?json=y&Hour=9&OneOrAll=All&Day=Tuesday");
            return await GetAsync<List<Course>>(requestUrl);
        }

        public async Task<Course> GetCurrentCourse(string hour, string day)
        {
            Uri requestUrl = CreateTimetableRequestUri(string.Empty, $"?json=y&Hour={hour}&OneOrAll=One&Day={day}");
            return await GetAsync<Course>(requestUrl);
        }
    }
}