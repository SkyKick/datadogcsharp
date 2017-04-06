using DataDogCSharp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Serializers
{
    public class DataDogPayloadSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var payload = value as DataDogPayload;
            writer.WriteStartObject();
            writer.WritePropertyName("series");

            writer.WriteStartArray();
            foreach(var dataMetric in payload.Series)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("metric");
                serializer.Serialize(writer, dataMetric.Metric);
                writer.WritePropertyName("type");
                serializer.Serialize(writer, dataMetric.Type);

                // DataDog expects points as an array of arrays
                writer.WritePropertyName("points");
                writer.WriteStartArray();
                foreach (var dataPoint in dataMetric.Points)
                {
                    writer.WriteStartArray();
                    serializer.Serialize(writer, dataPoint.PosixTime);
                    serializer.Serialize(writer, dataPoint.Value);
                    writer.WriteEndArray();
                }
                writer.WriteEndArray();

                writer.WritePropertyName("tags");
                serializer.Serialize(writer, dataMetric.Tags);

                writer.WritePropertyName("host");
                serializer.Serialize(writer, dataMetric.Host);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DataDogPayload).IsAssignableFrom(objectType);
        }
    }
}
