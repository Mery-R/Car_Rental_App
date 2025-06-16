using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.ViewModels;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Show_Cars_Control.xaml
    /// </summary>
    public partial class Show_Cars_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public ShowCarsViewModel ViewModel { get; set; }

        public Show_Cars_Control()
        {
            InitializeComponent();

            var cars = _carRepository.GetAllCars();
            ViewModel = new ShowCarsViewModel(cars);
            this.DataContext = ViewModel;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Search...")
            {
                SearchTextBox.Text = "";

            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search...";
            }
        }

        private void RentCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                var rentWindow = new Rent_Car_Window(selectedCar.CarId);
                bool? result = rentWindow.ShowDialog();

                if (result == true)
                {
                    RefreshCars();
                }
            }
            else
            {
                MessageBox.Show("Wybierz samochód do wypożyczenia.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ReturnCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                if ((CarStatus)selectedCar.StatusCar != CarStatus.Rented)
                {
                    MessageBox.Show("This car is not currently rented.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var reservationRepo = new ReservationRepository();
                var latestReservation = reservationRepo.GetActiveReservationByCarId(selectedCar.CarId);

                if (latestReservation == null)
                {
                    MessageBox.Show("No active reservation found for this car.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var customerRepo = new CustomerRepository();
                var customer = customerRepo.GetCustomerById(latestReservation.CustomerId);

                if (customer == null)
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var returnWindow = new Return_Car_Window(selectedCar, customer, latestReservation);
                if (returnWindow.ShowDialog() == true)
                {
                    RefreshCars();
                }
            }
            else
            {
                MessageBox.Show("Select a car to return.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshCars()
        {
            // Pobierz aktualną listę samochodów z repozytorium
            var cars = _carRepository.GetAllCars();

            // Wyczyść listę AllCars i dodaj na nowo
            ViewModel.AllCars.Clear();
            foreach (var car in cars)
            {
                ViewModel.AllCars.Add(car);
            }

            // Zastosuj filtr (w ViewModelu)
            ViewModel.ApplyFilter();
        }

        private void ReserveCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki obsługi przycisku "Reserve"
            MessageBox.Show("Rezerwacja samochodu została rozpoczęta.");
        }

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Dodaj tutaj logikę obsługi zdarzenia, jeśli jest potrzebna
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
