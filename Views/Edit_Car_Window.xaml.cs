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

            // Skopiuj dane do pól tekstowych
            BrandTextBox.Text = car.Brand;
            ModelTextBox.Text = car.Model;
            YearTextBox.Text = car.ProductionYear.ToString();
            PlateTextBox.Text = car.PlateNumber;
            AvailabilityCheckBox.IsChecked = car.Availability;

            EditedCar = new CarModel(car.Id, car.Brand, car.Model, car.ProductionYear, car.PlateNumber, car.Availability);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Zaktualizuj dane na podstawie pól tekstowych
            EditedCar.Brand = BrandTextBox.Text;
            EditedCar.Model = ModelTextBox.Text;

            int year;
            if (int.TryParse(YearTextBox.Text, out year))
            {
                EditedCar.ProductionYear = year;
            }
            else
            {
                MessageBox.Show("Podaj poprawny rok produkcji.", "B³¹d", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (year < 1886 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Rok produkcji musi byæ miêdzy 1886 a {DateTime.Now.Year}.", "B³¹d", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditedCar.ProductionYear = year;
            EditedCar.PlateNumber = PlateTextBox.Text;
            EditedCar.Availability = AvailabilityCheckBox.IsChecked ?? false;

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