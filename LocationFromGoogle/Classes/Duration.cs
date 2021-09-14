using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.Classes
{
    internal delegate DateTime TSToDTDelegate(long unixTimeStamp);
    internal delegate long DTToTSDelegate(DateTime dateTime);

    public class Duration
    {
        private DateTime _startTimestamp;
        private DateTime _endTimestamp;

        internal DateTime StartTimestamp { get => _startTimestamp; set => _startTimestamp = value; }
        public long StartTimestampMs
        {
            get
            {
                DTToTSDelegate tempDel = DateTimeToUnixTimeStamp;

                return tempDel(StartTimestamp);
            }
            set
            {
                TSToDTDelegate tempDel = UnixTimeStampToDateTime;

                StartTimestamp = tempDel(value);
            }
        }
        internal DateTime EndTimestamp { get => _endTimestamp; set => _endTimestamp = value; }
        public long EndTimestampMs
        {
            get
            {
                DTToTSDelegate tempDel = DateTimeToUnixTimeStamp;

                return tempDel(EndTimestamp);
            }
            set
            {
                TSToDTDelegate tempDel = UnixTimeStampToDateTime;

                EndTimestamp = tempDel(value);
            }
        }


        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private static long DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long unixTimeStamp = Convert.ToInt64(dateTime - dtDateTime);

            return unixTimeStamp;
        }
    }
}
