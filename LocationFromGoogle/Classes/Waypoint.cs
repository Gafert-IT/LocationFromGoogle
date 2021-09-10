using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class Waypoint
    {
        private int latE7;
        private int lngE7;

        public int LatE7 { get => latE7; set => latE7 = value; }
        public int LngE7 { get => lngE7; set => lngE7 = value; }
    }
}
