using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using DateTime = System.DateTime;

namespace MyMeetings.Converters
{
    public class DateTimeStringToTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToLongTimeString();
            var dateTime = DateTime.ParseExact((string) value, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
            return dateTime.ToShortTimeString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToLongTimeString();
            var dateTime = DateTime.ParseExact((string)value, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
            return dateTime.ToShortTimeString();
        }
    }
}
