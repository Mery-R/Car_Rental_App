using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.Views;
using System;
using System.Net;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Rental.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _isAccess;

        private IUserRepository userRepository;

        // Properties
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public bool IsAccess
        {
            get => _isAccess;
            set
            {
                _isAccess = value;
                OnPropertyChanged(nameof(IsAccess));
            }
        }

        // Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        // Command logic to determine if login is valid
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                             Password != null && Password.Length >= 3;
            return validData;
        }

        // Logic to execute the login command
        private void ExecuteLoginCommand(object obj)
        {
            var password = Password;

            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, password));

            if (isValidUser)
            {
                // Ustawienie aktualnego użytkownika
                App.CurrentUser = userRepository.GetByUsername(Username);

                // Ustawienie tożsamości
                Thread.CurrentPrincipal = new System.Security.Principal.GenericPrincipal(
                    new System.Security.Principal.GenericIdentity(Username), null);

                IsAccess = App.CurrentUser?.Access ?? false;

                if (IsAccess)
                {
                    var adminMenu = new Admin_Menu();
                    adminMenu.Show();
                }
                else
                {
                    var userMenu = new User_Menu();
                    userMenu.Show();
                }

                IsViewVisible = false;
            }

            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }


        // Logic for password recovery
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }


    }
}
