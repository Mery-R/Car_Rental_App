using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.ViewModels
{
    internal class CustomerManagementViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerModel> _customers;
        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }

        public CustomerManagementViewModel()
        {
            var repo = new CustomerRepository();
            Customers = new ObservableCollection<CustomerModel>(repo.GetAllCustomers());
        }
    }
}
