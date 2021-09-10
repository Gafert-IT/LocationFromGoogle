using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class WaypointPath
    {
        private List<Waypoint>? waypoints;

        public List<Waypoint>? Waypoints { get => waypoints; set => waypoints = value; }
    }
}
