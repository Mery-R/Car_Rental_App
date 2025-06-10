using Car_Rental.Models;
using System;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class AddCarWindow : Window
    {
        public Car AddedCar { get; private set; }

        public AddCarWindow(int newId)
        {
            InitializeComponent();
            AddedCar = new Car(newId, "", "", 2000, "", true);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Zaktualizuj dane na podstawie pól tekstowych
            AddedCar.Brand = BrandTextBox.Text;
            AddedCar.Model = ModelTextBox.Text;

            int year;
            if (int.TryParse(YearTextBox.Text, out year))
            {
                AddedCar.ProductionYear = year;
            }
            else
            {
                MessageBox.Show("Podaj poprawny rok produkcji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (year < 1886 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Rok produkcji musi być między 1886 a {DateTime.Now.Year}.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AddedCar.ProductionYear = year;
            AddedCar.PlateNumber = PlateTextBox.Text;
            AddedCar.Availability = AvailabilityCheckBox.IsChecked ?? false;

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