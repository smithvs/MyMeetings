using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using DateTime = System.DateTime;

namespace MyMeetings.Converters
{
    public class UpperDateTimeStringToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToShortDateString();
            return DateTime.ParseExact((string)value, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToShortDateString();
            return ((DateTime)value).ToShortDateString();
        }
    }
}
