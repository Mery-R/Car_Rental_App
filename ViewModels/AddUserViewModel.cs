using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Car_Rental.ViewModels
{
    internal class AddUserViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _name;
        private string _lastName;
        private string _email;
        private bool _access;

        private readonly UserRepository _userRepository;

        public AddUserViewModel()
        {
            _userRepository = new UserRepository();
            AddUserCommand = new RelayCommand(AddUser);
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public bool Access
        {
            get => _access;
            set { _access = value; OnPropertyChanged(); }
        }

        public ICommand AddUserCommand { get; }

        private void AddUser(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newUser = new UserModel
                {
                    Username = Username.Trim(),
                    Password = Password.Trim(), // Tu możesz dodać haszowanie
                    Name = Name.Trim(),
                    LastName = LastName.Trim(),
                    Email = Email.Trim(),
                    Access = Access
                };

                _userRepository.Add(newUser);

                MessageBox.Show("Użytkownik został dodany pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                // Możesz dodać reset pól lub inne akcje po dodaniu
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania użytkownika: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Access = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // Prosta implementacja ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
