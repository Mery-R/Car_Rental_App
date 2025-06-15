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
        public ObservableCollection<CarModel> Cars { get; private set; }
        private readonly CarRepository carRepo;

        public Car_List_ViewModel()
        {
            carRepo = new CarRepository();
            LoadCars();
        }

        private void LoadCars()
        {
            var carsFromDb = carRepo.GetAllCars();
            Cars = new ObservableCollection<CarModel>(carsFromDb);
        }

        public void AddCar()
        {
            var addWindow = new Add_Car_Window();

            if (addWindow.ShowDialog() == true)
            {
                var newCar = addWindow.NewCar;

                if (newCar != null)
                {
                    carRepo.AddCar(newCar); // zapis do bazy
                    LoadCars(); // odświeżenie widoku
                }
            }
        }


        public void RemoveCar(int carId)
        {
            var carToRemove = Cars.FirstOrDefault(c => c.CarId == carId);
            if (carToRemove != null)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć ten samochód?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    carRepo.DeleteCar(carId);
                    Cars.Remove(carToRemove);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateCar(CarModel updatedCar)
        {
            var existingCar = Cars.FirstOrDefault(c => c.CarId == updatedCar.CarId);

            if (existingCar != null)
            {
                carRepo.UpdateCar(updatedCar);
                LoadCars(); // ponowne załadowanie danych po aktualizacji
            }
            else
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym ID.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
