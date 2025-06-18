using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{
    public partial class Service_Car_Window : Window
    {
        private int carId; // CarId for the selected car
        private CarRepository _carRepository;
        private CarModel _currentCar;
        public ServiceModel NewService { get; private set; }
        private readonly int _carId;
        private readonly Action _refreshAction;

        public Service_Car_Window(int carId, Action refreshAction)
        {
            InitializeComponent();
            _carRepository = new CarRepository();
            _carId = carId;
            _refreshAction = refreshAction;
            StartDatePicker.SelectedDate = DateTime.Today;
            EndDatePicker.SelectedDate = DateTime.Today.AddDays(1);
            LoadCarList();
        }
        // Load all cars into the ListView
        private void LoadCarList()
        {
           
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Pobierz dane z kontrolek (dostosuj nazwy do swojego XAML)
                DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.Today;
                DateTime? endDate = EndDatePicker.SelectedDate;
                string description = DescriptionTextBox.Text ?? string.Empty;
                int statusService = StatusComboBox.SelectedIndex; // lub inny sposób pobrania statusu

                // Walidacja daty zakończenia
                if (!endDate.HasValue)
                {
                    MessageBox.Show("Wybierz datę zakończenia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (endDate < startDate)
                {
                    MessageBox.Show("Data zakończenia nie może być wcześniejsza niż data rozpoczęcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Utwórz model usługi
                var newService = new ServiceModel
                {
                    CarId = _carId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Description = description,
                    StatusService = statusService
                };

                // Dodaj usługę do bazy
                var serviceRepo = new ServiceRepository();
                serviceRepo.AddService(newService);

                // Zmień status auta na "Service" lub "Service in Progress"
                var carRepo = new CarRepository();
                var car = carRepo.GetCarById(_carId);
                if (car != null)
                {
                    // Jeśli data początkowa to dziś, ustaw ServiceInProgress, w przeciwnym razie Service (czyli ServicePlanned)
                    if (startDate.Date == DateTime.Today)
                        car.StatusCar = (int)CarStatus.ServiceInProgress;
                    else
                        car.StatusCar = (int)CarStatus.ServicePlanned;
                    carRepo.UpdateCar(car);
                }

                MessageBox.Show("Usługa została dodana, a status auta zaktualizowany.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                _refreshAction?.Invoke();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania usługi: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window when the user clicks 'Close'
        }
    }
}
