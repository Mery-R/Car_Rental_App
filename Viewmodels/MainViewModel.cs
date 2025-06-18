using Car_Rental.Models;
using Car_Rental.Repositories;
using FontAwesome.Sharp;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;

namespace Car_Rental.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserModel _currentUser = new UserModel();
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private readonly IUserRepository userRepository;
        private readonly SQLiteConnection DatabaseConnection;

        // Commands
        public ICommand ShowCarViewCommand { get; }
        public ICommand PricesViewCommand { get; }
        public ICommand HistoryViewCommand { get; }
        public ICommand FleetManagementViewCommand { get; }
        public ICommand UserManagementViewCommand { get; }
        public ICommand CustomerManagementViewCommand { get; }


        // Properties
        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Constructor
        public MainViewModel()
        {
            try
            {
                // Inicjalizacja połączenia z bazą danych z RepositoryBase
                var repositoryBase = new RepositoryBase();
                DatabaseConnection = repositoryBase.GetConnection();
                DatabaseConnection.Open();

                // Inicjalizacja UserRepository
                userRepository = new UserRepository();

                Debug.WriteLine("Połączenie z bazą danych zostało nawiązane.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd podczas łączenia z bazą danych: {ex.Message}");
            }

            // Inicjalizacja komend
            ShowCarViewCommand = new ViewModelCommand(ExecuteShowCarViewCommand);
            PricesViewCommand = new ViewModelCommand(ExecutePricesViewCommand);
            HistoryViewCommand = new ViewModelCommand(ExecuteHistoryViewCommand);
            FleetManagementViewCommand = new ViewModelCommand(ExecuteFleetManagementViewCommand);
            UserManagementViewCommand = new ViewModelCommand(ExecuteUserManagementViewCommand);
            CustomerManagementViewCommand = new ViewModelCommand(ExecuteCustomerManagementViewCommand);

            // Domyślny widok
            ExecuteShowCarViewCommand(null);

            // Załaduj dane użytkownika
            LoadCurrentUserData();
        }

        private void ExecuteShowCarViewCommand(object obj)
        {
            CurrentChildView = new ShowCarsViewModel();
            Caption = "Show cars";
            Icon = IconChar.Car;
        }
        private void ExecutePricesViewCommand(object obj)
        {
            CurrentChildView = new PricesViewModel();
            Caption = "Prices";
            Icon = IconChar.Tags;
        }
        private void ExecuteHistoryViewCommand(object obj)
        {
            CurrentChildView = new HistoryViewModel();
            Caption = "History";
            Icon = IconChar.ClockRotateLeft;
        }
        private void ExecuteFleetManagementViewCommand(object obj)
        {
            CurrentChildView = new FleetManagementViewModel();
            Caption = "Fleet management";
            Icon = IconChar.Gears;
        }
        private void ExecuteUserManagementViewCommand(object obj)
        {
            CurrentChildView = new UserManagementViewModel();
            Caption = "User management";
            Icon = IconChar.Briefcase;
        }

        private void ExecuteCustomerManagementViewCommand(object obj)
        {
            CurrentChildView = new CustomerManagementViewModel();
            Caption = "Customer management";
            Icon = IconChar.PeopleRoof;
        }

        private void LoadCurrentUserData()
        {
            try
            {
                var identityName = Thread.CurrentPrincipal?.Identity?.Name;

                if (!string.IsNullOrEmpty(identityName))
                {
                    var user = userRepository.GetByUsername(identityName);
                    if (user != null)
                    {
                        CurrentUser = user;
                    }
                    else
                    {
                        CurrentUser.Username = "Invalid user, not logged in";
                    }
                }
                else
                {
                    CurrentUser.Username = "No identity available";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd przy wczytywaniu danych użytkownika: {ex.Message}");
            }
        }
    }
}
