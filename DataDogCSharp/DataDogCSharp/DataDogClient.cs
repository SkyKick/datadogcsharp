using DataDogCSharp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp
{
    public class DataDogClient
    {
        private string apiUrl;
        private HttpClient httpClient;

        public DataDogClient(string apiKey, string url = "https://app.datadoghq.com/api/v1/series?api_key=")
        {
            apiUrl = $"{url}{apiKey}";
            httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> Gauge(string metric, IEnumerable<long[]> points, IEnumerable<string> tags)
        {
            DataDogMetric dataMetric = new DataDogMetric()
            {
                metric = metric,
                points = points,
                tags = tags,
                type = "gauge"
            };

            DataDogPayload payload = new DataDogPayload()
            {
                series = new List<DataDogMetric>() { dataMetric }
            };

            return await PostToDataDog(payload);

        }

        private async Task<HttpResponseMessage> PostToDataDog(DataDogPayload payload)
        {
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(apiUrl, content);
            return result;
        }
    }
}
