using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class Activity
    {
        private string? activityType;
        private double probability;

        public string? ActivityType { get => activityType; set => activityType = value; }
        public double Probability { get => probability; set => probability = value; }
    }

    internal enum ActivityType
    {
        IN_PASSENGER_VEHICLE,
        IN_VEHICLE,
        CYCLING
    }
}
