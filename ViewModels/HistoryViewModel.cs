// File: HistoryViewModel.cs
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
        public string HistoryText { get; set; }
        public ObservableCollection<object> FilteredItems { get; set; }

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
            var reservationRepo = new ReservationRepository();
            var serviceRepo = new ServiceRepository();

            Reservations = new ObservableCollection<ReservationModel>(reservationRepo.GetAllReservations());
            Services = new ObservableCollection<ServiceModel>(serviceRepo.GetAllServices());

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
