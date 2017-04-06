using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Models
{
    public class DataDogMetric
    {
        public string Metric;
        public IEnumerable<DataDogPoint> Points;
        public string Type;
        public IEnumerable<string> Tags;
        public string Host;
    }
}
