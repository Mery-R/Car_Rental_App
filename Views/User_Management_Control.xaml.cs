using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();

        public User_Management_Control()
        {
            InitializeComponent();
            DataContext = this; // Ustaw DataContext, aby binding działał
            LoadUsers();
        }

        private void LoadUsers()
        {
            var repo = new UserRepository();
            Users.Clear();
            foreach (var user in repo.GetByAll())
            {
                Users.Add(user);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new Add_User_Window();
            bool? result = addUserWindow.ShowDialog();

            if (result == true && addUserWindow.UserAdded)
            {
                LoadUsers(); // odświeżamy listę po dodaniu
            }
        }


        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserDataGrid.SelectedItem as UserModel;
            if (selectedUser == null)
            {
                MessageBox.Show("Proszę wybrać użytkownika do usunięcia.", "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Czy na pewno chcesz usunąć użytkownika {selectedUser.Username}?",
                "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var repo = new UserRepository();
                    repo.Remove(selectedUser.UserId);

                    Users.Remove(selectedUser); // usuwa z ObservableCollection, co automatycznie odświeża UI

                    MessageBox.Show("Użytkownik został usunięty.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania użytkownika: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Edycja istniejącego samochodu
        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserDataGrid.SelectedItem as UserModel;
            if (selectedUser == null)
            {
                MessageBox.Show("Proszę wybrać użytkownika do edycji.", "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editWindow = new Edit_User_Window(selectedUser);
            bool? result = editWindow.ShowDialog();

            if (result == true && editWindow.UserEdited)
            {
                LoadUsers(); // odśwież listę po edycji
            }
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

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
