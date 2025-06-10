using Car_Rental.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System;

namespace Car_Rental.Services
{
    public static class CarDataService
    {
        private static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cars.json"); // Ścieżka do pliku JSON w folderze aplikacji

        public static void SaveCars(List<Car> cars)
        {
            // Zapisz Cars do pliku
            var json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static (List<Car> Cars, int NextId) LoadCars()
        {
            if (!File.Exists(FilePath))
                return (new List<Car>(), 1);  // Jeśli plik nie istnieje, rozpocznij od 1

            var json = File.ReadAllText(FilePath);
            var cars = JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();

            // Wydobycie nextId z ostatniego samochodu
            int nextId = cars.Count > 0 ? cars.Max(c => c.Id) + 1 : 1;

            return (cars, nextId);
        }
    }
}
