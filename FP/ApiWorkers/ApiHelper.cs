using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FP.Models;
using Newtonsoft.Json;

namespace FP.ApiWorkers
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;

        #region Constructors

        public ApiClient(Uri baseEndpoint, Uri weatherEndpoint, Uri openWeatherEndpoint, Uri timetableBaseEndpoint)
        {
            BaseEndpoint = baseEndpoint ?? throw new ArgumentNullException(nameof(baseEndpoint));
            WeatherEndpoint = weatherEndpoint;
            OpenWeatherEndpoint = openWeatherEndpoint;
            TimetableEndpoint = timetableBaseEndpoint;

            _httpClient = new HttpClient();
        }

        #endregion

        #region  Properties

        private Uri BaseEndpoint { get; }

        private Uri WeatherEndpoint { get; }

        private Uri OpenWeatherEndpoint { get; }

        private Uri TimetableEndpoint { get; }

        private static JsonSerializerSettings MicrosoftDateFormatSettings => new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        };

        #endregion

        /// <summary>
        ///     Common method for making GET calls
        /// </summary>
        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            AddHeaders();

            HttpResponseMessage response =
                await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            string data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        ///     Common method for making POST calls
        /// </summary>
        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {
            AddHeaders();
            HttpResponseMessage response =
                await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }

        private async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            AddHeaders();
            HttpResponseMessage response =
                await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T1>>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            Uri endpoint = new Uri(BaseEndpoint, relativePath);
            UriBuilder uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private Uri CreateWeatherRequestUri(string relativePath, string queryString = "")
        {
            Uri endpoint = new Uri(WeatherEndpoint, relativePath);
            UriBuilder uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private Uri CreateOpenWeatherRequestUri(string relativePath, string queryString = "")
        {
            Uri endpoint = new Uri(OpenWeatherEndpoint, relativePath);
            UriBuilder uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private Uri CreateTimetableRequestUri(string relativePath, string queryString = "")
        {
            Uri endpoint = new Uri(TimetableEndpoint, relativePath);
            UriBuilder uriBuilder = new UriBuilder(endpoint) {Query = queryString};
            return uriBuilder.Uri;
        }


        private HttpContent CreateHttpContent<T>(T content)
        {
            string json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void AddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}