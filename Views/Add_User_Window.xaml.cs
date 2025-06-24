using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{
    public partial class Add_User_Window : Window
    {
        private readonly UserRepository _userRepository;

        public bool UserAdded { get; private set; } = false;

        public Add_User_Window()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newUser = new UserModel
                {
                    Username = UsernameTextBox.Text.Trim(),
                    Password = PasswordBox.Password.Trim(), // Tutaj możesz dodać haszowanie hasła
                    Name = FirstNameTextBox.Text.Trim(),
                    LastName = LastNameTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                    Access = AccessCheckBox.IsChecked == true
                };

                _userRepository.Add(newUser);

                UserAdded = true;  // ustawiamy flagę, że użytkownik został dodany

                MessageBox.Show("Użytkownik został dodany pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true; // zamyka okno z wynikiem OK
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania użytkownika: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
