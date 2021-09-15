using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationFromGoogle.Core;

namespace LocationFromGoogle.Classes
{
    public class Duration
    {
        // StarTimeStamp in UnixTimestamp and DateTime
        private long _StartTimestampMs;
        private DateTime _StartTimestampDT;
        public long StartTimestampMs
        {
            get { return _StartTimestampMs; }
            set
            {
                StartTimestampDT = UnixTimeStampToDateTime(value);
                _StartTimestampMs = value;
            }
        }
        public DateTime StartTimestampDT
        {
            get { return _StartTimestampDT; }
            set { _StartTimestampDT = value; }
        }

        // EndTimeStamp in UnixTimestamp and DateTime
        private long _EndTimestampMs;
        private DateTime _EndTimestampDT;
        public long EndTimestampMs
        {
            get { return _EndTimestampMs; }
            set
            {               
                EndTimestampDT = UnixTimeStampToDateTime(value);
                _EndTimestampMs = value;
            }
        }
        public DateTime EndTimestampDT
        {
            get { return _EndTimestampDT; }
            set { _EndTimestampDT = value; }
        }

        // Converter
        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
