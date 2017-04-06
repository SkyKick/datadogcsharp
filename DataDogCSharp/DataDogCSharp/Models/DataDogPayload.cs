using DataDogCSharp.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Models
{
    [JsonConverter(typeof(DataDogPayloadSerializer))]
    public class DataDogPayload
    {
        public IEnumerable<DataDogMetric> Series;
    }
}
