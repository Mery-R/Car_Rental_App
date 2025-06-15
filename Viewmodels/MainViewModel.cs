using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Car_Rental.Models;
using Car_Rental.Repositories;
using FontAwesome.Sharp;

namespace Car_Rental.ViewModels
{
    public class MainViewModel : ViewModelBase 
    {
        //Fields
 
        private UserModel _currentUser;

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

      

        public UserModel CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowCarViewCommand { get; }
        public ICommand PricesViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUser = new UserModel();

            ShowCarViewCommand = new ViewModelCommand(ExecuteShowCarViewCommand);
            PricesViewCommand = new ViewModelCommand(ExecutePricesViewCommand);

            ExecuteShowCarViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecutePricesViewCommand(object obj)
        {
            CurrentChildView = new PricesViewModel();
            Caption = "Prices";
            Icon = IconChar.Tags;
        }

        private void ExecuteShowCarViewCommand(object obj)
        {
            CurrentChildView = new ShowCarsViewModel();
            Caption = "Show cars";
            Icon = IconChar.Car;
        }

        private void LoadCurrentUserData()
        {
            var identityName = Thread.CurrentPrincipal?.Identity?.Name;

            var user = userRepository.GetByUsername(identityName);
            if (user != null)
            {
                CurrentUser.Username = user.Username;
            }
            else
            {
                CurrentUser.Username = "Invalid user, not logged in";
            }
        }

    }
}
