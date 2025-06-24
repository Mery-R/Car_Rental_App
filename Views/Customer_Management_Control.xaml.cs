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
            var addCustomerWindow = new Add_Customer_Window();
            addCustomerWindow.ShowDialog();

            // Opcjonalnie: odśwież listę klientów po dodaniu
            var viewModel = DataContext as CustomerManagementViewModel;
            viewModel?.LoadCustomers(); // Załóżmy, że masz taką metodę
        }


        // Edycja istniejącego samochodu
        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as CustomerManagementViewModel;
            var selectedCustomer = CustomerDataGrid.SelectedItem as CustomerModel;

            if (selectedCustomer != null)
            {
                var editWindow = new Edit_Customer_Window(selectedCustomer);
                if (editWindow.ShowDialog() == true)
                {
                    viewModel?.LoadCustomers(); // odświeżenie danych po edycji
                }
            }

        }

        private void RemoveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if(CustomerDataGrid.SelectedItem is CustomerModel selectedCustomer)

                {
                    var result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedCustomer.FirstName} {selectedCustomer.LastName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (DataContext is CustomerManagementViewModel vm)
                    {
                        vm.RemoveCustomer(selectedCustomer);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
