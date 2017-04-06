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
        public long Value;

        public DataDogPoint(long value)
        {
            PosixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            this.Value = value;
        }
    }
}
