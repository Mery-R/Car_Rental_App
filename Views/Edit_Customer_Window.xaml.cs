using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class Edit_Customer_Window : Window
    {
        private CustomerModel _customer;

        public Edit_Customer_Window(CustomerModel customer)
        {
            InitializeComponent();
            _customer = customer;
            FillForm();
        }

        private void FillForm()
        {
            FirstNameBox.Text = _customer.FirstName;
            LastNameBox.Text = _customer.LastName;
            EmailBox.Text = _customer.Email;
            PhoneBox.Text = _customer.Phone;
            PeselBox.Text = _customer.PESEL;
            LicenseBox.Text = _customer.DriverLicenseNumber;
            DateOfBirthPicker.SelectedDate = _customer.DateOfBirth;
            StreetBox.Text = _customer.Street;
            CityBox.Text = _customer.City;
            PostalCodeBox.Text = _customer.PostalCode;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _customer.FirstName = FirstNameBox.Text;
            _customer.LastName = LastNameBox.Text;
            _customer.Email = EmailBox.Text;
            _customer.Phone = PhoneBox.Text;
            _customer.PESEL = PeselBox.Text;
            _customer.DriverLicenseNumber = LicenseBox.Text;
            _customer.DateOfBirth = DateOfBirthPicker.SelectedDate ?? DateTime.MinValue;
            _customer.Street = StreetBox.Text;
            _customer.City = CityBox.Text;
            _customer.PostalCode = PostalCodeBox.Text;

            var repo = new CustomerRepository();
            repo.UpdateCustomer(_customer);

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
