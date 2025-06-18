using System;
using System.Globalization;
using System.Windows.Data;

namespace Car_Rental.Converters
{
    public class AccessToRoleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool accessBool)
                return accessBool ? "Admin" : "User";
            if (value is int accessInt)
                return accessInt == 1 ? "Admin" : "User";
            return "User";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
                return str == "Admin" ? 1 : 0;
            return 0;
        }
    }
}