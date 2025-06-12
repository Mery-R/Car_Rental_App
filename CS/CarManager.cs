using Car_Rental.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Car_Rental.Services
{
    public class CarManager
    {
        private List<CarModel> cars = new List<CarModel>(); // Lista przechowująca samochody

        public List<CarModel> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        // Metoda do dodawania samochodu
        public void AddCar(CarModel car)
        {
            cars.Add(car);
        }

        // Metoda do usuwania samochodu
        public void RemoveCar(int carId)
        {
            var carToRemove = cars.FirstOrDefault(c => c.Id == carId);
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
            }
        }

        public void UpdateCar(CarModel updatedCar)
        {
            // Znajdź istniejący samochód w kolekcji
            var existingCar = cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            if (existingCar != null)
            {
                // Zaktualizuj dane samochodu
                existingCar.Brand = updatedCar.Brand;
                existingCar.Model = updatedCar.Model;
                existingCar.ProductionYear = updatedCar.ProductionYear;
                existingCar.PlateNumber = updatedCar.PlateNumber;
                existingCar.Availability = updatedCar.Availability;
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
