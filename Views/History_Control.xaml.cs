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

        private readonly ReservationRepository _reservationRepository = new ReservationRepository();

        private void EditHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationsDataGrid.SelectedItem is ReservationModel selectedReservation)
            {
                var editWindow = new Edit_Reservation_Window(selectedReservation);
                if (editWindow.ShowDialog() == true)
                {
                    // Po zamknięciu okna edycji, odśwież dane
                    LoadReservations();
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to edit.", "No selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationsDataGrid.SelectedItem is ReservationModel selectedReservation)
            {
                var result = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _reservationRepository.DeleteReservation(selectedReservation.ReservationId);
                        MessageBox.Show("Reservation deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadReservations(); // Odświeżenie widoku po usunięciu
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.", "No selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadReservations()
        {
            var reservations = _reservationRepository.GetAllReservations();
            ReservationsDataGrid.ItemsSource = reservations;
        }
    }
}
