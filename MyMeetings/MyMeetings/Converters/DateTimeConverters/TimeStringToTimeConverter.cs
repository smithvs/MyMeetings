using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyMeetings.Converters
{
    public class TimeStringToTimeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.TimeOfDay;
            return DateTime.ParseExact((string) value, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.ToShortTimeString();
            return (new DateTime() + ((TimeSpan)value)).ToShortTimeString();
        }
    }
}
