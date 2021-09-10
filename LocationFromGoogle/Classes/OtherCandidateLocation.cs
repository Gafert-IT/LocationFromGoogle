using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class OtherCandidateLocation
    {
        private int latitudeE7;
        private int longitudeE7;
        private string? placeId;
        private string? name;
        private double locationConfidence;

        public int LatitudeE7 { get => latitudeE7; set => latitudeE7 = value; }
        public int LongitudeE7 { get => longitudeE7; set => longitudeE7 = value; }
        public string? PlaceId { get => placeId; set => placeId = value; }
        public string? Name { get => name; set => name = value; }
        public double LocationConfidence { get => locationConfidence; set => locationConfidence = value; }
    }
}
