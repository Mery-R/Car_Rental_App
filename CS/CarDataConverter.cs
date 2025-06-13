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
                case 0: return "Benzyna";
                case 1: return "Diesel";
                case 2: return "Elektryczny";
                case 3: return "Hybryda";
                default: return "Nieznany";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            switch (str)
            {
                case "Benzyna": return 0;
                case "Diesel": return 1;
                case "Elektryczny": return 2;
                case "Hybryda": return 3;
                default: return 0;
            }
        }
    }

    public class GearboxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int gearbox = (int)value;
            return gearbox == 0 ? "Manualna" : "Automatyczna";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            return str == "Automatyczna" ? 1 : 0;
        }
    }

    public class StatusCarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int status = (int)value;
            switch (status)
            {
                case 0: return "Dostępny";
                case 1: return "Zarezerwowany";
                case 2: return "Wypożyczony";
                case 3: return "Serwis";
                default: return "Nieznany";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str == null) return 0;
            switch (str)
            {
                case "Dostępny": return 0;
                case "Zarezerwowany": return 1;
                case "Wypożyczony": return 2;
                case "Serwis": return 3;
                default: return 0;
            }
        }
    }
}
