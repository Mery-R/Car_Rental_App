using System;
using System.Globalization;
using System.Windows.Data;

namespace Car_Rental.Converters
{
    public class FuelTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int type = (int)value;
            switch (type)
            {
                case 0: return "Gasoline";
                case 1: return "Diesel";
                case 2: return "Electric";
                case 3: return "Hybrid";
                default: return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            switch (str)
            {
                case "Gasoline": return 0;
                case "Diesel": return 1;
                case "Electric": return 2;
                case "Hybrid": return 3;
                default: return 0;
            }
        }
    }

    public class GearboxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int gearbox = (int)value;
            return gearbox == 0 ? "Manual" : "Automatic";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            return str == "Automatic" ? 1 : 0;
        }
    }

    public class StatusCarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int status = (int)value;
            switch (status)
            {
                case 0: return "Available";
                case 1: return "Reserved";
                case 2: return "Rented";
                case 3: return "Service";
                default: return "Unknow";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            switch (str)
            {
                case "Available": return 0;
                case "Reserved": return 1;
                case "Rented": return 2;
                case "Service": return 3;
                default: return 0;
            }
        }
    }
}
