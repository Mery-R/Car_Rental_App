using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Linq;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class Edit_Reservation_Window : Window
    {
        private readonly ReservationModel _reservation;
        private readonly ReservationRepository _reservationRepository;
        private readonly CarRepository _carRepository;
        private readonly CustomerRepository _customerRepository;

        public Edit_Reservation_Window(ReservationModel reservation)
        {
            InitializeComponent();
            _reservation = reservation;

            // Initialize repositories
            _reservationRepository = new ReservationRepository();
            _carRepository = new CarRepository();
            _customerRepository = new CustomerRepository();

            // Set the DataContext to bind reservation model
            DataContext = _reservation;

            // Load cars for ComboBox
            LoadCars();
            LoadReservationStatuses();
        }

        private void LoadCars()
        {
            // Load all cars for the combo box to select a car for the reservation
            var cars = _carRepository.GetAllCars();
            foreach (var car in cars)
            {
                CarComboBox.Items.Add(new { car.CarId, DisplayName = $"{car.Brand} {car.Model} ({car.LicensePlate})" });
            }

            // Set the default selected car
            var selectedCar = cars.FirstOrDefault(c => c.CarId == _reservation.CarId);
            if (selectedCar != null)
            {
                CarComboBox.SelectedItem = new { selectedCar.CarId, DisplayName = $"{selectedCar.Brand} {selectedCar.Model} ({selectedCar.LicensePlate})" };
            }
        }

        private void LoadReservationStatuses()
        {
            // Zakładając, że masz kolekcję statusów rezerwacji w formie Enum
            var statuses = Enum.GetValues(typeof(ReservationStatus)); // Pobierz wszystkie wartości z Enum ReservationStatus
            StatusComboBox.SelectedValue = _reservation.StatusReservation; // Ustawienie statusu na podstawie modelu rezerwacji

            foreach (var status in statuses)
            {
                // Dodaj statusy do ComboBox (StatusComboBox)
                StatusComboBox.Items.Add(new
                {
                    Status = status.ToString(),
                    Value = (int)status // Możesz dopasować wartość numeru lub identyfikatora statusu
                });
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected car from the ComboBox
            if (CarComboBox.SelectedItem != null)
            {
                _reservation.CarId = ((dynamic)CarComboBox.SelectedItem).CarId;
            }

            // Get the selected status from the ComboBox
            if (StatusComboBox.SelectedItem != null)
            {
                _reservation.StatusReservation = ((dynamic)StatusComboBox.SelectedItem).Value;
            }

            // Update the reservation in the database
            _reservationRepository.UpdateReservation(_reservation);

            // Close the window and inform the user
            MessageBox.Show("Reservation updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            DialogResult = false;
            Close();
        }
    }
}
