using Car_Rental.Models;
using Car_Rental.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;



namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Fleet_Management_Window.xaml
    /// </summary>
    public partial class Fleet_Management_Window : Window
    {
        private readonly CarRepository _carRepository = new CarRepository(); // Repository for accessing car data
        public Fleet_Management_Window()
        {
            InitializeComponent();
            LoadCars(_carRepository);
        }

        private void LoadCars(CarRepository carRepository)
        {
            List<CarModel> cars = carRepository.GetAllCars();
            CarDataGrid.ItemsSource = cars;
        }
        private void RefreshCarList()
        {
            var cars = _carRepository.GetAllCars(); // używa pola klasy
            CarDataGrid.ItemsSource = cars;
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var addCarWindow = new Add_Car_Window();
            if (addCarWindow.ShowDialog() == true)
            {
                CarModel newCar = addCarWindow.NewCar;
                _carRepository.AddCar(newCar);       // ✅ poprawione
                RefreshCarList();                    // ❌ tu kolejny problem
            }

        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
