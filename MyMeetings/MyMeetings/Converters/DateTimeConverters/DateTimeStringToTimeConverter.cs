using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using DateTime = System.DateTime;

namespace MyMeetings.Converters
{
    public class DateTimeStringToTimeConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.TimeOfDay;
            var dateTime = DateTime.ParseExact((string) value, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
            return dateTime.TimeOfDay;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (parameter as EntryCell).Text == null)
                return DateTime.Now.ToLongTimeString();
            var day = DateTime.ParseExact((parameter as EntryCell).Text, "yyyy.MM.dd", CultureInfo.InvariantCulture).Date; 
            
            return (day + (TimeSpan)value).ToString("yyyy.MM.dd HH.mm");
        }
    }
}
