using Car_Rental.Models;
using Car_Rental.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Car_Rental.Views;

namespace Car_Rental.ViewModels
{
    public class Car_List_ViewModel
    {
        public ObservableCollection<CarModel> Cars { get; set; }
        private CarRepository carRepo;

        public Car_List_ViewModel()
        {
            carRepo = new CarRepository();
            var carsFromDb = carRepo.GetAllCars();
            Cars = new ObservableCollection<CarModel>(carsFromDb);
        }

        public void AddCar()
        {
            int newId = Cars.Any() ? Cars.Max(c => c.Id) + 1 : 1;
            var addWindow = new AddCarWindow(newId);
            if (addWindow.ShowDialog() == true)
            {
                carRepo.AddCar(addWindow.AddedCar);
                Cars.Add(addWindow.AddedCar);
            }
        }

        public void RemoveCar(int carId)
        {
            var carToRemove = Cars.FirstOrDefault(c => c.Id == carId);
            if (carToRemove != null)
            {
                carRepo.DeleteCar(carId);
                Cars.Remove(carToRemove);
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
                existingCar.Brand = updatedCar.Brand;
                existingCar.Model = updatedCar.Model;
                existingCar.ProductionYear = updatedCar.ProductionYear;
                existingCar.PlateNumber = updatedCar.PlateNumber;
                existingCar.Availability = updatedCar.Availability;

                carRepo.UpdateCar(existingCar);
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
