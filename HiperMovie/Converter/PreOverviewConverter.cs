using System;
using System.Globalization;
using Xamarin.Forms;

namespace HiperMovie.Converter
{
    public class PreOverviewConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var over = (string) value;
            if (over.Length > 100)
            {
                return string.Format(@"{0}...", over.Substring(0, 100));
            } 
            else 
            {
                return string.Format(@"{0}...", over);
			}

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
