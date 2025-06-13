// Plik: CarManager.cs
// Przeznaczenie: Klasa zarządzająca kolekcją samochodów. Umożliwia dodawanie, usuwanie i aktualizowanie pojazdów w aplikacji Car_Rental.

using Car_Rental.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Car_Rental.Services
{
    /// <summary>
    /// Klasa CarManager zarządza listą samochodów i operacjami na niej.
    /// </summary>
    public class CarManager
    {
        private List<CarModel> cars = new List<CarModel>(); // Lista przechowująca samochody

        /// <summary>
        /// Właściwość przechowująca kolekcję samochodów.
        /// </summary>
        public List<CarModel> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        /// <summary>
        /// Dodaje nowy samochód do kolekcji.
        /// </summary>
        public void AddCar(CarModel car)
        {
            cars.Add(car);
        }

        /// <summary>
        /// Usuwa samochód o podanym ID z kolekcji.
        /// </summary>
        public void RemoveCar(int carId)
        {
            var carToRemove = cars.FirstOrDefault(c => c.Id == carId);
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
            }
        }

        /// <summary>
        /// Aktualizuje dane istniejącego samochodu na podstawie przekazanego modelu.
        /// </summary>
        public void UpdateCar(CarModel updatedCar)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            if (existingCar != null)
            {
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
