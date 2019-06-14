using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Configuration;
using FP.Models;
using FP.Models.Fitbit;

namespace FP.ApiWorkers
{
    public partial class ApiClient
    {
        public async Task<StatsModel> GetStats(string date)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, $"stats/{date}"));
            return await GetAsync<StatsModel>(requestUrl);
        }

        public async Task<Message<StatsModel>> SaveStats(StatsModel model)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "stats"));
            return await PostAsync(requestUrl, model);
        }


        public async Task<List<CaloriesModel>> GetCalories()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "calories"));
            return await GetAsync<List<CaloriesModel>>(requestUrl);
        }

        public async Task<Message<List<CaloriesModel>>> SaveCalories(List<CaloriesModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "calories"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<ActiveMinutesModel>> GetMinutes()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "activeMinutes"));
            return await GetAsync<List<ActiveMinutesModel>>(requestUrl);
        }

        public async Task<Message<List<ActiveMinutesModel>>> SaveMinutes(List<ActiveMinutesModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "activeMinutes"));
            return await PostAsync(requestUrl, models);
        }


        public async Task<List<DistanceModel>> GetDistance()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "distance"));
            return await GetAsync<List<DistanceModel>>(requestUrl);
        }

        public async Task<Message<List<DistanceModel>>> SaveDistances(List<DistanceModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "distance"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<SleepModel>> GetSleep()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "sleep"));
            return await GetAsync<List<SleepModel>>(requestUrl);
        }

        public async Task<Message<List<SleepModel>>> SaveSleep(List<SleepModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "sleep"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<FloorsModel>> GetFloors()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "floors"));
            return await GetAsync<List<FloorsModel>>(requestUrl);
        }

        public async Task<Message<List<FloorsModel>>> SaveFloors(List<FloorsModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "floors"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<WeigthModel>> GetWeight()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "weight"));
            return await GetAsync<List<WeigthModel>>(requestUrl);
        }

        public async Task<Message<List<WeigthModel>>> SaveWeigth(List<WeigthModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "weight"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<StepsModel>> GetSteps()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "steps"));
            return await GetAsync<List<StepsModel>>(requestUrl);
        }

        public async Task<Message<List<StepsModel>>> SaveSteps(List<StepsModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "steps"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<List<HeartRateModel>> GetHeartRate()
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture, "hr"));
            return await GetAsync<List<HeartRateModel>>(requestUrl);
        }

        public async Task<Message<List<HeartRateModel>>> SaveHeartRate(List<HeartRateModel> models)
        {
            Uri requestUrl = CreateRequestUri(string.Format(CultureInfo.InvariantCulture,
                "hr"));
            return await PostAsync(requestUrl, models);
        }

        public async Task<string> PostTwitter(string message)
        {
            Uri uri = new Uri(WebConfigurationManager.AppSettings["TwitterUrlBase"]);
            Uri endpoint = new Uri(uri, string.Format(CultureInfo.InvariantCulture, $"{uri}{message}"));
            UriBuilder uriBuilder = new UriBuilder(endpoint);

            return await GetAsync<string>(uriBuilder.Uri);
        }
    }
}