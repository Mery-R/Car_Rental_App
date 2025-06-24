using Car_Rental.Models;
using Car_Rental.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Car_Rental.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public ObservableCollection<ReservationModel> Reservations { get; set; }
        public ObservableCollection<ServiceModel> Services { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }
        public ObservableCollection<object> FilteredItems { get; set; }

        public UserModel CurrentUser { get; set; }


        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                ApplyFilter();
            }
        }

        private bool _isShowingReservations = true;
        public bool IsShowingReservations
        {
            get => _isShowingReservations;
            set
            {
                _isShowingReservations = value;
                OnPropertyChanged(nameof(IsShowingReservations));
                ApplyFilter();
            }
        }

        public HistoryViewModel()
        {
            // Przypisanie aktualnie zalogowanego użytkownika
            CurrentUser = App.CurrentUser;

            CurrentUser = App.CurrentUser ?? new UserModel { Username = "Unknown" };

            var reservationRepo = new ReservationRepository();
            var serviceRepo = new ServiceRepository();
            var carRepo = new CarRepository();
            var customerRepo = new CustomerRepository();
            var userRepo = new UserRepository();

            Reservations = new ObservableCollection<ReservationModel>(reservationRepo.GetAllReservations());
            Services = new ObservableCollection<ServiceModel>(serviceRepo.GetAllServices());
            Cars = new ObservableCollection<CarModel>(carRepo.GetAllCars());

            var customers = customerRepo.GetAllCustomers();
            var users = userRepo.GetByAll();

            var customerNameDict = customers.ToDictionary(
                c => c.CustomerId,
                c => $"{c.FirstName} {c.LastName}"
            );

            var customerPESELDict = customers.ToDictionary(
                c => c.CustomerId,
                c => c.PESEL
            );

            var userDict = users.ToDictionary(u => u.UserId, u => u.Username);

            var carDict = Cars.ToDictionary(c => c.CarId, c => c.LicensePlate);

            foreach (var reservation in Reservations)
            {
                reservation.LicensePlate = carDict.ContainsKey(reservation.CarId) ? carDict[reservation.CarId] : "Unknown";
                reservation.CustomerFullName = customerNameDict.ContainsKey(reservation.CustomerId) ? customerNameDict[reservation.CustomerId] : "Unknown";
                reservation.CustomerPESEL = customerPESELDict.ContainsKey(reservation.CustomerId) ? customerPESELDict[reservation.CustomerId] : "Unknown";
                reservation.UserName = userDict.ContainsKey(reservation.UserId) ? userDict[reservation.UserId] : "Unknown";  // <-- login teraz
            }


            foreach (var service in Services)
            {
                service.LicensePlate = carDict.ContainsKey(service.CarId) ? carDict[service.CarId] : "Unknown";
            }

            FilteredItems = new ObservableCollection<object>();
            ApplyFilter();
        }



        private void ApplyFilter()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
