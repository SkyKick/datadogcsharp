using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Models
{
    public class DataDogMetric
    {
        public string metric;
        public IEnumerable<long[]> points;
        public string type;
        public IEnumerable<string> tags;
    }
}
