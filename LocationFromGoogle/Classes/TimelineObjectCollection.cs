using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class TimelineObjectCollection
    {
        private List<TimelineObject>? timelineObjects;

        public List<TimelineObject> TimelineObjects { get => timelineObjects; set => timelineObjects = value; }
    }
}
