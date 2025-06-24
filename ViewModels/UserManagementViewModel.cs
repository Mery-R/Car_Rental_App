using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Models;
using Car_Rental.Repositories;
using System.Collections.ObjectModel;

namespace Car_Rental.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _users;
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(nameof(Users)); }
        }

        // Dodaj to pole, aby mieć dostęp do repozytorium
        private readonly UserRepository _userRepository;

        public UserManagementViewModel()
        {
            _userRepository = new UserRepository();  // inicjalizacja repozytorium
            Users = new ObservableCollection<UserModel>(_userRepository.GetByAll());
        }

        public void AddUser(UserModel newUser)
        {
            _userRepository.Add(newUser);
            Users.Add(newUser);
        }
    }
}
