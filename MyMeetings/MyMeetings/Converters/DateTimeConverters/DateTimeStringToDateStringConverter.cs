using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using DateTime = System.DateTime;

namespace MyMeetings.Converters
{
    public class DateTimeStringToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToShortDateString();
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToShortDateString();
            return ((DateTime)value).ToShortDateString();
        }
    }
}
