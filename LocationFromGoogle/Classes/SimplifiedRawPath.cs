using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    public class SimplifiedRawPath
    {
        private List<Point>? points;

        public List<Point>? Points { get => points; set => points = value; }
    }
}
