using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{
    public partial class Rent_Car_Window : Window
    {
        private readonly int _carId;
        private readonly CarRepository _carRepository = new CarRepository();
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        private readonly ReservationRepository _reservationRepository = new ReservationRepository();
        public ReservationModel Reservation { get; private set; }

        private CarModel _car;

        public Rent_Car_Window(int carId)
        {
            InitializeComponent();
            _carId = carId;
            LoadCarDetails();
            LoadCustomers();
            // Ustawienie dzisiejszej daty jako domyślnej w kontrolkach DatePicker
            StartDatePicker.SelectedDate = DateTime.Today;
        }

        private void LoadCarDetails()
        {
            _car = _carRepository.GetCarById(_carId);
            if (_car != null)
            {
                CarDetailsText.Text = $"{_car.Brand} {_car.Model} | Reg: {_car.LicensePlate} | Mileage: {_car.Mileage} km";
                DepositText.Text = $"{_car.Deposit} PLN";
            }
        }

        private void LoadCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            CustomerComboBox.ItemsSource = customers;
            CustomerComboBox.DisplayMemberPath = "FullName";
            CustomerComboBox.SelectedValuePath = "CustomerId";
        }

        private void CalculatePrice()
        {
            if (StartDatePicker.SelectedDate is DateTime start &&
                EndDatePicker.SelectedDate is DateTime end)
            {
                if (end <= start)
                {
                    MessageBox.Show("End date must be after start date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double days = (end - start).TotalDays;
                float price = CalculateTotalPrice(days);
                TotalPriceText.Text = $"{price} PLN";  // Upewnij się, że wyświetlamy cenę
            }
        }
        private float CalculateTotalPrice(double days)
        {
            if (days <= 3)
                return (float)(days * _car.DailyPrice_1_3);
            else if (days <= 8)
                return (float)(days * _car.DailyPrice_4_8);
            else if (days <= 15)
                return (float)(days * _car.DailyPrice_9_15);
            else if (days <= 29)
                return (float)(days * _car.DailyPrice_16_29);
            else
                return (float)(days * _car.DailyPrice_30plus);
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePrice();  // Oblicz cenę po zmianie daty rozpoczęcia
        }

        // Obsługuje zmianę daty zakończenia
        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePrice();  // Oblicz cenę po zmianie daty zakończenia
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue is int customerId &&
                StartDatePicker.SelectedDate is DateTime start &&
                EndDatePicker.SelectedDate is DateTime end)
            {
                // Sprawdzenie, czy data zakończenia jest po dacie rozpoczęcia
                if (end <= start)
                {
                    MessageBox.Show("End date must be after start date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Tworzenie nowej rezerwacji
                Reservation = new ReservationModel
                {
                    CarId = _carId,
                    CustomerId = customerId,
                    UserId = 1, // lub dynamicznie – w zależności od zalogowanego użytkownika
                    StartDate = start,
                    EndDate = end,
                    StatusReservation = (int)ReservationStatus.Active,
                    TotalPrice = float.Parse(TotalPriceText.Text.Split(' ')[0]) // Pobieranie ceny z tekstu wyświetlanego w kontrolce
                };

                try
                {
                    _reservationRepository.AddReservation(Reservation);

                    // Zmieniamy status samochodu
                    if (start.Date == DateTime.Today)
                    {
                        _car.StatusCar = (int)CarStatus.Rented; // Samochód jest już wypożyczony
                        _carRepository.UpdateCar(_car);
                        MessageBox.Show("Car has been rented.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        _car.StatusCar = (int)CarStatus.Reserved; // Samochód jest zarezerwowany na przyszłość
                        _carRepository.UpdateCar(_car);
                        MessageBox.Show("Car has been reserved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }

                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Reservation failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer and set dates.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Add_Customer_Window();
            if (addWindow.ShowDialog() == true)
            {
                LoadCustomers(); // Odśwież listę
                CustomerComboBox.SelectedValue = addWindow.NewCustomerId; // Ustaw nowego klienta jako wybranego
            }
        }

    }
}
