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

        public UserManagementViewModel()
        {
            var repo = new UserRepository();
            Users = new ObservableCollection<UserModel>(repo.GetByAll());
        }
    }
}
