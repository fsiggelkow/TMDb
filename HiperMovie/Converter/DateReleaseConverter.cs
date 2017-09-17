using System;
using System.Globalization;
using Xamarin.Forms;

namespace HiperMovie.Converter
{
    public class DateReleaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime) value;
            var stDate = date.ToString("yyyy");
            if (stDate == "2017")
            {
                return Color.FromHex("#FFE5E5");
            }
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
