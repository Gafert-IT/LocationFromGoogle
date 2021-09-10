using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class TimelineObject
    {
        private ActivitySegment? activitySegment;
        private PlaceVisit? placeVisit;

        public ActivitySegment? ActivitySegment { get => activitySegment; set => activitySegment = value; }
        public PlaceVisit? PlaceVisit { get => placeVisit; set => placeVisit = value; }
    }
}
