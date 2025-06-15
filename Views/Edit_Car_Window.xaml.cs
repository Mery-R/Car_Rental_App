using Car_Rental.Models;
using System;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class EditCarWindow : Window
    {
        public CarModel EditedCar { get; private set; }

        public EditCarWindow(CarModel car)
        {
            InitializeComponent();

            // Wype�nij pola danymi z istniej�cego auta
            BrandTextBox.Text = car.Brand;
            ModelTextBox.Text = car.Model;
            YearTextBox.Text = car.ProductionYear.ToString();
            PlateTextBox.Text = car.LicensePlate;
            AvailabilityCheckBox.IsChecked = car.StatusCar == 0;

            // Skopiuj dane do nowego obiektu (opcjonalnie: mo�esz pracowa� bezpo�rednio na oryginale)
            EditedCar = new CarModel
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                ProductionYear = car.ProductionYear,
                LicensePlate = car.LicensePlate,
                StatusCar = car.StatusCar,

                // Inne w�a�ciwo�ci przepisz, je�li s� potrzebne
                VIN = car.VIN,
                Engine = car.Engine,
                FuelType = car.FuelType,
                Gearbox = car.Gearbox,
                VehicleClass = car.VehicleClass,
                Color = car.Color,
                Mileage = car.Mileage,
                DailyPrice_1_3 = car.DailyPrice_1_3,
                DailyPrice_4_8 = car.DailyPrice_4_8,
                DailyPrice_9_15 = car.DailyPrice_9_15,
                DailyPrice_16_29 = car.DailyPrice_16_29,
                DailyPrice_30plus = car.DailyPrice_30plus,
                WeekendPrice = car.WeekendPrice,
                Deposit = car.Deposit,
                ImagePath = car.ImagePath
            };
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            EditedCar.Brand = BrandTextBox.Text;
            EditedCar.Model = ModelTextBox.Text;

            if (!int.TryParse(YearTextBox.Text, out int year))
            {
                MessageBox.Show("Podaj poprawny rok produkcji.", "B��d", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (year < 1886 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Rok produkcji musi by� mi�dzy 1886 a {DateTime.Now.Year}.", "B��d", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditedCar.ProductionYear = year;
            EditedCar.LicensePlate = PlateTextBox.Text;
            EditedCar.StatusCar = AvailabilityCheckBox.IsChecked == true ? 0 : 2; // 0 = dost�pny, 2 = niedost�pny

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
