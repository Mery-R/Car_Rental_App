using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Show_Cars_Control.xaml
    /// </summary>
    public partial class Show_Cars_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public ShowCarsViewModel ViewModel { get; set; }

        public Popup FiltersPopupPublic => FiltersPopup;

        public Show_Cars_Control()
        {
            InitializeComponent();

            var cars = _carRepository.GetAllCars();
            ViewModel = new ShowCarsViewModel(cars);
            this.DataContext = ViewModel;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
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
                // Akceptuj zarówno Rented, jak i Service
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

        private void ServiceCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                int carId = selectedCar.CarId;
                // Przekazanie delegata do odświeżenia
                Service_Car_Window serviceCarWindow = new Service_Car_Window(carId, RefreshCars);
                serviceCarWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a car to add a service.", "No Car Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RentedCarButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AvailableCarButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public void RefreshCars()
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

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Dodaj tutaj logikę obsługi zdarzenia, jeśli jest potrzebna
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                    case CarStatus.ServiceInProgress:
                        ViewModel.IsInServiceChecked = cb.IsChecked == true;
                        break;
                        // itd. jeśli masz Maintenance
                }
            }
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
        
    }
}
