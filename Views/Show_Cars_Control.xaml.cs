using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Car_Rental.Models;
using Car_Rental.Views;
using Car_Rental.Repositories;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Show_Cars_Window.xaml
    /// </summary>
    public partial class Show_Cars_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository(); // Repository for accessing car data

        public Show_Cars_Control()
        {
            InitializeComponent();
            LoadCars(_carRepository);
        }

        private void LoadCars(CarRepository carRepository)
        {
            List<CarModel> cars = carRepository.GetAllCars();
            CarDataGrid.ItemsSource = cars;
        }
        private void RefreshCarList(CarRepository carRepository)
        {
            var cars = carRepository.GetAllCars();
            CarDataGrid.ItemsSource = cars;
        }

        private void RentCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                var rentWindow = new Rent_Car_Window(selectedCar.CarId);
                bool? result = rentWindow.ShowDialog();

                if (result == true)
                {
                    // Odśwież listę samochodów
                    LoadCars(_carRepository);
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
                    LoadCars(_carRepository);
                }
            }
            else
            {
                MessageBox.Show("Select a car to return.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        private void ReserveCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
