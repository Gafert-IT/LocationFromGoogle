using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class ActivitySegment
    {
        private StartLocation? startLocation;
        private EndLocation? endLocation;
        private Duration? duration;
        private int distance;
        private string? confidence;
        private List<Activity>? activities;
        private WaypointPath? waypointPath;
        private string? editConfirmationStatus;
        private SimplifiedRawPath? simplifiedRawPath;
        private string? activityType;

        public StartLocation? StartLocation { get => startLocation; set => startLocation = value; }
        public EndLocation? EndLocation { get => endLocation; set => endLocation = value; }
        public Duration? Duration { get => duration; set => duration = value; }
        public int Distance { get => distance; set => distance = value; }
        public string? Confidence { get => confidence; set => confidence = value; }
        public List<Activity>? Activities { get => activities; set => activities = value; }
        public WaypointPath? WaypointPath { get => waypointPath; set => waypointPath = value; }
        public string? EditConfirmationStatus { get => editConfirmationStatus; set => editConfirmationStatus = value; }
        public SimplifiedRawPath? SimplifiedRawPath { get => simplifiedRawPath; set => simplifiedRawPath = value; }
        public string? ActivityType { get => activityType; set => activityType = value; }
    }

    internal enum EditConfirmationStatus
    {
        NOT_CONFIRMED
    }

    internal enum Confidence
    {
        MEDIUM
    }
}
