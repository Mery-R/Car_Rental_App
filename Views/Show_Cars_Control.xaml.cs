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
           
        }



        private void ReturnCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReserveCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
