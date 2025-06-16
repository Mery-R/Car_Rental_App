using Car_Rental.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Car_Rental.ViewModels
{
    public class ShowCarsViewModel : ViewModelBase
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

        // Public parameterless constructor
        public ShowCarsViewModel()
        {
            // Initialization logic (if any)
        }

        public ShowCarsViewModel(List<CarModel> cars)
        {
            AllCars = new ObservableCollection<CarModel>(cars);
            FilteredCars = new ObservableCollection<CarModel>(AllCars);
        }


        public void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredCars = new ObservableCollection<CarModel>(AllCars);
            }
            else
            {
                var lower = SearchText.ToLower();
                var filtered = AllCars.Where(car =>
                    (car.Brand?.ToLower().Contains(lower) ?? false) ||
                    (car.Model?.ToLower().Contains(lower) ?? false) ||
                    (car.LicensePlate?.ToLower().Contains(lower) ?? false) ||
                    (car.Color?.ToLower().Contains(lower) ?? false)
                ).ToList();

                FilteredCars = new ObservableCollection<CarModel>(filtered);
            }
            // Usunięto OnPropertyChanged tutaj, bo jest już w setterze FilteredCars
        }

 
    }
}
