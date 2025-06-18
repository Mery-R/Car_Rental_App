using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Fleet_Management_Control.xaml
    /// </summary>
    public partial class Fleet_Management_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public ShowCarsViewModel ViewModel { get; set; }

        public Fleet_Management_Control()
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

        // Dodawanie nowego samochodu
        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Add_Car_Window();
            if (addWindow.ShowDialog() == true)
            {
                RefreshCars();
            }
        }

        // Edycja istniejącego samochodu
        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarDataGrid.SelectedItem is CarModel selectedCar)
            {
                var editWindow = new Edit_Car_Window(selectedCar);
                if (editWindow.ShowDialog() == true)
                {
                    RefreshCars();
                }
            }
            else
            {
                MessageBox.Show("Select a car to edit.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Zakładając, że masz DataGrid z samochodami
            var selectedCar = CarDataGrid.SelectedItem as CarModel; // CarDataGrid to przykład, dostosuj do swojego przypadku

            if (selectedCar != null)
            {
                // Potwierdzenie przed usunięciem
                var result = MessageBox.Show($"Czy na pewno chcesz usunąć samochód {selectedCar.Brand} {selectedCar.Model}?",
                                              "Potwierdzenie usunięcia", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var carRepository = new CarRepository(); // Tworzenie instancji repozytorium
                        carRepository.DeleteCar(selectedCar.CarId); // Wywołanie metody usuwania

                        // Odświeżenie widoku, np. zaktualizowanie listy samochodów w DataGrid
                        RefreshCars();
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędów, jeśli usunięcie się nie uda
                        MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz samochód do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshCars()
        {
            var cars = _carRepository.GetAllCars();

            ViewModel.AllCars.Clear();
            foreach (var car in cars)
            {
                ViewModel.AllCars.Add(car);
            }

            ViewModel.ApplyFilter();
        }

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ewentualna logika zaznaczenia
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
