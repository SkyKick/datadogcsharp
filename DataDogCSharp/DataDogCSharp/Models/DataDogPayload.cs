using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Models
{
    public class DataDogPayload
    {
        public IEnumerable<DataDogMetric> series;
    }
}
