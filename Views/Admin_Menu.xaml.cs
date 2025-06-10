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
using System.Windows.Shapes;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_Menu.xaml
    /// </summary>
    public partial class Admin_Menu : Window
    {
        public Admin_Menu()
        {
            InitializeComponent();
        }

        private void ShowCarsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Car_List carListWindow = new Car_List(); // Zmiana z CarListWindow na Car_List
            carListWindow.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Pick up a car"
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Manage fleet"
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Log out"
        }

        private void Button_Clic5(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Rent a car"
        }

        private void Button_Clic6(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Raport"
        }
    }
}
