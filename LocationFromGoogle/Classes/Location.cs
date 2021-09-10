using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class Location
    {
        private int latitudeE7;
        private int longitudeE7;
        private string? placeId;
        private string? address;
        private string? name;
        private SourceInfo? sourceInfo;
        private double? locationConfidence;
        private string? semanticType;

        public int LatitudeE7 { get => latitudeE7; set => latitudeE7 = value; }
        public int LongitudeE7 { get => longitudeE7; set => longitudeE7 = value; }
        public string? PlaceId { get => placeId; set => placeId = value; }
        public string? Address { get => address; set => address = value; }
        public string? Name { get => name; set => name = value; }
        public SourceInfo? SourceInfo { get => sourceInfo; set => sourceInfo = value; }
        public double? LocationConfidence { get => locationConfidence; set => locationConfidence = value; }
        public string? SemanticType { get => semanticType; set => semanticType = value; }
    }
}
