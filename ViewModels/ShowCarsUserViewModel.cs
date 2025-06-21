using Car_Rental.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Car_Rental.ViewModels
{
    public class ShowCarsUserViewModel : ViewModelBase
    {
        private string searchText;

        public ObservableCollection<CarModel> AllCars { get; set; }

        private ObservableCollection<CarModel> filteredCars;

        public ObservableCollection<CarModel> FilteredCars
        {
            get => filteredCars;
            set
            {
                if (filteredCars != value)
                {
                    filteredCars = value;
                    OnPropertyChanged(nameof(FilteredCars));
                }
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    ApplyFilter();
                }
            }
        }

        public ShowCarsUserViewModel()
        {
            // Initialization logic (if any)
        }

        public ShowCarsUserViewModel(List<CarModel> cars)
        {
            AllCars = new ObservableCollection<CarModel>(cars);
            FilteredCars = new ObservableCollection<CarModel>(AllCars);
        }

        public void ApplyFilter()
        {
            var selectedStatuses = new List<int>();
            if (IsAvailableChecked) selectedStatuses.Add((int)CarStatus.Available);
            if (IsReservedChecked) selectedStatuses.Add((int)CarStatus.Reserved);
            if (IsRentedChecked) selectedStatuses.Add((int)CarStatus.Rented);

            // Pomijamy status ServiceInProgress

            var lower = SearchText?.ToLower() ?? "";

            var filtered = AllCars
                .Where(car =>
                    selectedStatuses.Contains((int)car.Status) &&
                    (
                        string.IsNullOrWhiteSpace(lower) ||
                        (car.Brand?.ToLower().Contains(lower) ?? false) ||
                        (car.Model?.ToLower().Contains(lower) ?? false) ||
                        (car.LicensePlate?.ToLower().Contains(lower) ?? false) ||
                        (car.Color?.ToLower().Contains(lower) ?? false)
                    )
                ).ToList();

            FilteredCars = new ObservableCollection<CarModel>(filtered);
        }

        private bool isAvailableChecked = true;
        public bool IsAvailableChecked
        {
            get => isAvailableChecked;
            set
            {
                if (isAvailableChecked != value)
                {
                    isAvailableChecked = value;
                    OnPropertyChanged(nameof(IsAvailableChecked));
                    ApplyFilter();
                }
            }
        }

        private bool isReservedChecked = true;
        public bool IsReservedChecked
        {
            get => isReservedChecked;
            set
            {
                if (isReservedChecked != value)
                {
                    isReservedChecked = value;
                    OnPropertyChanged(nameof(IsReservedChecked));
                    ApplyFilter();
                }
            }
        }

        private bool isRentedChecked = true;
        public bool IsRentedChecked
        {
            get => isRentedChecked;
            set
            {
                if (isRentedChecked != value)
                {
                    isRentedChecked = value;
                    OnPropertyChanged(nameof(IsRentedChecked));
                    ApplyFilter();
                }
            }
        }
    }
}
