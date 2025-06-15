using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class Add_Customer_Window : Window
    {
        public int NewCustomerId { get; private set; }

        public Add_Customer_Window()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCustomer = new CustomerModel
                {
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                    Email = EmailBox.Text,
                    Phone = PhoneBox.Text,
                    PESEL = PeselBox.Text,
                    DriverLicenseNumber = LicenseBox.Text,
                    DateOfBirth = DateOfBirthPicker.SelectedDate ?? DateTime.Today,
                    Street = StreetBox.Text,
                    City = CityBox.Text,
                    PostalCode = PostalCodeBox.Text
                };

                var repo = new CustomerRepository();
                NewCustomerId = repo.AddCustomer(newCustomer); // Dodaj i zwróć ID

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
