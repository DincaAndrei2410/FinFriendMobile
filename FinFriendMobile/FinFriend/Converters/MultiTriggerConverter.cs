using System;
using System.Globalization;
using Xamarin.Forms;

namespace FinFriend.Converters
{
	public class MultiTriggerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((int)value > 2) 
                return true;           
            else
                return false;  
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

