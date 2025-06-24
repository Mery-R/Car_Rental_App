using Car_Rental.Models;
using Car_Rental.Repositories;
using System.Collections.ObjectModel;

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

        private readonly CustomerRepository _repository;

        public CustomerManagementViewModel()
        {
            _repository = new CustomerRepository();
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<CustomerModel>(_repository.GetAllCustomers());
        }

        public void RemoveCustomer(CustomerModel customer)
        {
            if (customer == null) return;

            _repository.DeleteCustomer(customer.CustomerId);
            LoadCustomers(); // odświeżenie listy po usunięciu
        }


    }
}
