using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Customer_Management_Control.xaml
    /// </summary>
    public partial class Customer_Management_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public Customer_Management_Control()
        {
            InitializeComponent();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        // Dodawanie nowego samochodu
        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Edycja istniejącego samochodu
        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void RefreshCustomers()
        {

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
