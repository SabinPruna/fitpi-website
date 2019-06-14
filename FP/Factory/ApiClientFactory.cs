using System;
using System.Threading;
using System.Web.Configuration;
using FP.ApiWorkers;

namespace FP.Factory
{
    internal static class ApiClientFactory
    {
        private static readonly Uri FitbitApiUri;
        private static readonly Uri RoomApiUrl;
        private static readonly Uri OpenWeatherUri;
        private static readonly Uri TimetableUri;

        private static readonly Lazy<ApiClient> RestClient = new Lazy<ApiClient>(
            () => new ApiClient(FitbitApiUri, RoomApiUrl, OpenWeatherUri, TimetableUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        #region Constructors

        static ApiClientFactory()
        {
            FitbitApiUri = new Uri(WebConfigurationManager.AppSettings["FitbitUrlBase"]);
            RoomApiUrl = new Uri(WebConfigurationManager.AppSettings["WeatherUrl"]);
            OpenWeatherUri = new Uri(WebConfigurationManager.AppSettings["OpenWeatherUrl"]);
            TimetableUri = new Uri(WebConfigurationManager.AppSettings["TimetableUrl"]);
        }

        #endregion

        #region  Properties

        public static ApiClient Instance => RestClient.Value;

        #endregion
    }
}