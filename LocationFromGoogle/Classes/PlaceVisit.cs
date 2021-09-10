using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class PlaceVisit
    {
        private Location? location;
        private Duration? duration;
        private string? placeConfidence;
        private int centerLatE7;
        private int centerLngE7;
        private int visitConfidence;
        private List<OtherCandidateLocation>? otherCandidateLocations;
        private string? editConfirmationStatus;

        public Location? Location { get => location; set => location = value; }
        public Duration? Duration { get => duration; set => duration = value; }
        public string? PlaceConfidence { get => placeConfidence; set => placeConfidence = value; }
        public int CenterLatE7 { get => centerLatE7; set => centerLatE7 = value; }
        public int CenterLngE7 { get => centerLngE7; set => centerLngE7 = value; }
        public int VisitConfidence { get => visitConfidence; set => visitConfidence = value; }
        public List<OtherCandidateLocation>? OtherCandidateLocations { get => otherCandidateLocations; set => otherCandidateLocations = value; }
        public string? EditConfirmationStatus { get => editConfirmationStatus; set => editConfirmationStatus = value; }
    }

    internal enum PlaceConfidence
    {
        HIGH_CONFIDENCE
    }
}
