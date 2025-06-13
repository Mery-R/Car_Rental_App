using Car_Rental.Models;
using Car_Rental.Services;
using System.Linq; // Dodano using dla LINQ
using System.Windows;

namespace Car_Rental.Views
{
    /// <summary>
    /// Klasa Car_List odpowiada za logikę zarządzania listą samochodów.
    /// </summary>
    public partial class Car_List : Window
    {
        private CarManager carManager;

        /// <summary>
        /// Konstruktor inicjalizujący okno oraz wczytujący samochody z pliku.
        /// </summary>
        public Car_List()
        {
            InitializeComponent();

            // Wczytaj samochody z pliku
            var (loadedCars, _) = CarDataService.LoadCars();
            carManager = new CarManager();
            carManager.Cars = loadedCars;

            // Przypisz Cars z CarManager jako źródło danych DataGrid
            CarDataGrid.ItemsSource = carManager.Cars;
        }

        /// <summary>
        /// Obsługuje dodawanie nowego samochodu do listy.
        /// </summary>
        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var newCarId = GenerateNewCarId();
            var addWindow = new AddCarWindow(newCarId);
            if (addWindow.ShowDialog() == true)
            {
                // Zaktualizuj samochód w managerze
                carManager.AddCar(addWindow.AddedCar);

                // Zapisz do pliku po dodaniu
                CarDataService.SaveCars(carManager.Cars);

                // Odśwież widok
                CarDataGrid.ItemsSource = null;
                CarDataGrid.ItemsSource = carManager.Cars;
            }
        }

        /// <summary>
        /// Generuje nowe unikalne ID dla samochodu.
        /// </summary>
        private int GenerateNewCarId()
        {
            return carManager.Cars.Any() ? carManager.Cars.Max(c => c.Id) + 1 : 1;
        }

        /// <summary>
        /// Obsługuje usuwanie wybranego samochodu z listy.
        /// </summary>
        private void RemoveCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                carManager.RemoveCar(selectedCar.Id);

                // Zapisz do pliku po usunięciu
                CarDataService.SaveCars(carManager.Cars);

                // Odśwież widok
                CarDataGrid.ItemsSource = null;
                CarDataGrid.ItemsSource = carManager.Cars;
            }
            else
            {
                MessageBox.Show("Wybierz samochód do usunięcia.");
            }
        }

        /// <summary>
        /// Obsługuje edytowanie danych wybranego samochodu.
        /// </summary>
        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                var editWindow = new EditCarWindow(selectedCar);
                if (editWindow.ShowDialog() == true)
                {
                    // Edytuj samochód w managerze
                    carManager.UpdateCar(editWindow.EditedCar);

                    // Zapisz do pliku po edycji
                    CarDataService.SaveCars(carManager.Cars);

                    // Odśwież widok
                    CarDataGrid.ItemsSource = null;
                    CarDataGrid.ItemsSource = carManager.Cars;
                }
            }
            else
            {
                MessageBox.Show("Wybierz samochód do edytowania.");
            }
        }
    }
}
