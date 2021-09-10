using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class Point
    {
        private int latE7;
        private int lngE7;
        private string? timestampMs;
        private int accuracyMeters;

        public int LatE7 { get => latE7; set => latE7 = value; }
        public int LngE7 { get => lngE7; set => lngE7 = value; }
        public string? TimestampMs { get => timestampMs; set => timestampMs = value; }
        public int AccuracyMeters { get => accuracyMeters; set => accuracyMeters = value; }
    }
}
