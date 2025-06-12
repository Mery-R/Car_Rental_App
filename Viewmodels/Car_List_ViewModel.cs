using Car_Rental.Models;
using Car_Rental.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Car_Rental.Views;

namespace Car_Rental.ViewModels
{
    public class Car_List_ViewModel
    {
        public ObservableCollection<CarModel> Cars { get; set; }

        public Car_List_ViewModel()
        {
            var (loadedCars, _) = CarDataService.LoadCars(); // Rozpakowanie krotki
            Cars = new ObservableCollection<CarModel>(loadedCars);
        }

        public void AddCar()
        {
            int newId = Cars.Any() ? Cars.Max(c => c.Id) + 1 : 1;
            var addWindow = new AddCarWindow(newId);
            if (addWindow.ShowDialog() == true)
            {
                Cars.Add(addWindow.AddedCar);
                // Zapisz do pliku, jeśli trzeba
            }
        }

        public void RemoveCar(int carId)
        {
            var carToRemove = Cars.FirstOrDefault(c => c.Id == carId);
            if (carToRemove != null)
            {
                Cars.Remove(carToRemove);
                CarDataService.SaveCars(Cars.ToList());  // Zapisz zmiany w pliku
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateCar(CarModel updatedCar)
        {
            var existingCar = Cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            if (existingCar != null)
            {
                // Zaktualizuj dane istniejącego samochodu
                existingCar.Brand = updatedCar.Brand;
                existingCar.Model = updatedCar.Model;
                existingCar.ProductionYear = updatedCar.ProductionYear;
                existingCar.PlateNumber = updatedCar.PlateNumber;
                existingCar.Availability = updatedCar.Availability;

                // Zapisz zmiany
                CarDataService.SaveCars(Cars.ToList());  // Zapisz zmiany w pliku
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
