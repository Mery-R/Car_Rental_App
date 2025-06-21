using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Show_Cars_User_Control.xaml
    /// </summary>
    public partial class Show_Cars_User_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public ShowCarsUserViewModel ViewModel { get; set; }

        public Popup FiltersPopupPublic => FiltersPopup;

        public Show_Cars_User_Control()
        {
            InitializeComponent();

            var cars = _carRepository.GetAllCars();
            ViewModel = new ShowCarsUserViewModel(cars);
            this.DataContext = ViewModel;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Implementacja jeśli potrzebna
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Implementacja jeśli potrzebna
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
                MessageBox.Show("Choose a car to rent.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ReturnCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                var status = (CarStatus)selectedCar.StatusCar;
                if (status != CarStatus.Rented)
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

        private void FiltersButton_Click(object sender, RoutedEventArgs e)
        {
            FiltersPopup.IsOpen = !FiltersPopup.IsOpen;
        }

        private void FilterCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && Enum.TryParse<CarStatus>(cb.Content.ToString(), out var status))
            {
                switch (status)
                {
                    case CarStatus.Available:
                        ViewModel.IsAvailableChecked = cb.IsChecked == true;
                        break;
                    case CarStatus.Reserved:
                        ViewModel.IsReservedChecked = cb.IsChecked == true;
                        break;
                    case CarStatus.Rented:
                        ViewModel.IsRentedChecked = cb.IsChecked == true;
                        break;
                   
                }
            }
        }

        public void RefreshCars()
        {
            var cars = _carRepository.GetAllCars();

            ViewModel.AllCars.Clear();
            foreach (var car in cars)
            {
                ViewModel.AllCars.Add(car);
            }

            ViewModel.ApplyFilter();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FiltersPopup.IsOpen && !IsClickInsidePopup(e))
            {
                FiltersPopup.IsOpen = false;
            }
        }

        private bool IsClickInsidePopup(MouseButtonEventArgs e)
        {
            if (FiltersPopup.Child is UIElement popupContent)
            {
                Point clickPos = e.GetPosition(popupContent);
                Rect bounds = new Rect(0, 0, popupContent.RenderSize.Width, popupContent.RenderSize.Height);
                return bounds.Contains(clickPos);
            }
            return false;
        }

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // opcjonalna logika
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // opcjonalna logika
        }
    }
}
