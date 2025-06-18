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
    /// Logika interakcji dla klasy Management_Window.xaml
    /// </summary>
    public partial class User_Management_Control : UserControl
    {
        public User_Management_Control()
        {
            InitializeComponent();
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
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
     
        }

        // Edycja istniejącego samochodu
        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RefreshCars()
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
