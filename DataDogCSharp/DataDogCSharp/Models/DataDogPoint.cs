using DataDogCSharp.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDogCSharp.Models
{
    public class DataDogPoint
    {
        public long PosixTime;
        public double Value;

        public DataDogPoint(double value)
        {
            PosixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            this.Value = value;
        }

        public DataDogPoint(long time, double value)
        {
            PosixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            this.Value = value;
        }
    }
}
