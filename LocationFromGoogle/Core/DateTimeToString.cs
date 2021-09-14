using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LocationFromGoogle.Core
{
    public class DateTimeToString : IValueConverter
    {
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime DateTimeValue = (DateTime)value;
            return DateTimeValue.ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();
            DateTime DateTimeValue;
            if (DateTime.TryParse(strValue, out DateTimeValue))
                return DateTimeValue;
            return value;
        }
    }
}
