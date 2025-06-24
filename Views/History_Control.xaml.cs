using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.ViewModels;
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
    /// Logika interakcji dla klasy History_Control.xaml
    /// </summary>
    public partial class History_Control : UserControl
    {
        private readonly CarRepository _carRepository = new CarRepository();
        public History_Control()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
            ShowReservationsButton.Visibility = Visibility.Collapsed;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void EditHistoryButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteHistoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowReservations_Click(object sender, RoutedEventArgs e)
        {
            // Pokaż sekcję rezerwacji, ukryj sekcję usług
            ReservationsContent.Visibility = Visibility.Visible;
            ServicesContent.Visibility = Visibility.Collapsed;

            // Zmień widoczność przycisków
            ShowReservationsButton.Visibility = Visibility.Collapsed;
            ShowServicesButton.Visibility = Visibility.Visible;
        }

        private void ShowServices_Click(object sender, RoutedEventArgs e)
        {
            // Pokaż sekcję usług, ukryj sekcję rezerwacji
            ServicesContent.Visibility = Visibility.Visible;
            ReservationsContent.Visibility = Visibility.Collapsed;

            // Zmień widoczność przycisków
            ShowReservationsButton.Visibility = Visibility.Visible;
            ShowServicesButton.Visibility = Visibility.Collapsed;
        }


        private void RefreshHistory()
        {

        }
        private void CarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ewentualna logika zaznaczenia
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ReservationsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
