using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Windows;

namespace Car_Rental.Views
{
    public partial class Edit_User_Window : Window
    {
        private UserModel _user;
        public bool UserEdited { get; set; } = false;

        public Edit_User_Window(UserModel user)
        {
            InitializeComponent();
            _user = user;

            // Wczytaj dane użytkownika do kontrolek
            UsernameTextBox.Text = _user.Username;
            FirstNameTextBox.Text = _user.Name;
            LastNameTextBox.Text = _user.LastName;
            EmailTextBox.Text = _user.Email;
            AccessCheckBox.IsChecked = _user.Access;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _user.Username = UsernameTextBox.Text;
            _user.Name = FirstNameTextBox.Text;
            _user.LastName = LastNameTextBox.Text;
            _user.Email = EmailTextBox.Text;
            _user.Access = AccessCheckBox.IsChecked ?? false;

            try
            {
                var repo = new UserRepository();

                // Najpierw aktualizujemy dane oprócz hasła
                repo.Edit(_user);

                // Jeśli wpisano nowe hasło, to aktualizujemy je osobno (dodaj metodę UpdatePassword w repo)
                if (!string.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    repo.UpdatePassword(_user.UserId, PasswordBox.Password);
                }

                UserEdited = true;
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania użytkownika: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
