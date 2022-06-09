using DataDogCSharp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp
{
    public interface IDataDogClient
    {
        Task<HttpResponseMessage> Gauge(string metric, double point, IEnumerable<string> tags);
        Task<HttpResponseMessage> Gauge(string metric, IEnumerable<double> points, IEnumerable<string> tags);
        Task<HttpResponseMessage> Gauge(string metric, IEnumerable<DataDogPoint> points, IEnumerable<string> tags);
        Task<HttpResponseMessage> PostToDataDog(DataDogPayload payload);
    }

    public class DataDogClient : IDataDogClient
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public DataDogClient(string apiKey, string url = "https://app.datadoghq.com/api/v1/series?api_key=")
        {
            _apiUrl = $"{url}{apiKey}";
            _httpClient = new HttpClient();
        }
        public async Task<HttpResponseMessage> Gauge(string metric, double point, IEnumerable<string> tags)
        {
            var dataPoints = new List<DataDogPoint> { new DataDogPoint(point) };
            return await Gauge(metric, dataPoints, tags);
        }

        public async Task<HttpResponseMessage> Gauge(string metric, IEnumerable<double> points, IEnumerable<string> tags)
        {
            var dataPoints = points.Select(p => new DataDogPoint(p));
            return await Gauge(metric, dataPoints, tags);
        }

        public async Task<HttpResponseMessage> Gauge(string metric, IEnumerable<DataDogPoint> points, IEnumerable<string> tags)
        {
            DataDogMetric dataMetric = new DataDogMetric
            {
                Metric = metric,
                Points = points,
                Tags = tags,
                Type = "gauge"
            };

            DataDogPayload payload = new DataDogPayload()
            {
                Series = new List<DataDogMetric> { dataMetric }
            };

            return await PostToDataDog(payload);
        }

        public async Task<HttpResponseMessage> PostToDataDog(DataDogPayload payload)
        {
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(_apiUrl, content);
            return result;
        }
    }
}
