using System.ComponentModel;

namespace Car_Rental.Models
{
    public class CarModel : INotifyPropertyChanged
    {
        private int carId;
        private string brand;
        private string model;
        private int productionYear;
        private string licensePlate;
        private string vin;
        private string engine;
        private int fuelType;
        private int gearbox;
        private string vehicleClass;
        private string color;
        private int mileage;
        private int statusCar;
        private float dailyPrice_1_3;
        private float dailyPrice_4_8;
        private float dailyPrice_9_15;
        private float dailyPrice_16_29;
        private float dailyPrice_30plus;
        private float weekendPrice;
        private float deposit;
        private string imagePath;

        public int CarId
        {
            get => carId;
            set { if (carId != value) { carId = value; OnPropertyChanged(nameof(CarId)); } }
        }

        public string Brand
        {
            get => brand;
            set { if (brand != value) { brand = value; OnPropertyChanged(nameof(Brand)); } }
        }

        public string Model
        {
            get => model;
            set { if (model != value) { model = value; OnPropertyChanged(nameof(Model)); } }
        }

        public int ProductionYear
        {
            get => productionYear;
            set { if (productionYear != value) { productionYear = value; OnPropertyChanged(nameof(ProductionYear)); } }
        }

        public string LicensePlate
        {
            get => licensePlate;
            set { if (licensePlate != value) { licensePlate = value; OnPropertyChanged(nameof(LicensePlate)); } }
        }

        public string VIN
        {
            get => vin;
            set { if (vin != value) { vin = value; OnPropertyChanged(nameof(VIN)); } }
        }

        public string Engine
        {
            get => engine;
            set { if (engine != value) { engine = value; OnPropertyChanged(nameof(Engine)); } }
        }

        public int FuelType
        {
            get => fuelType;
            set { if (fuelType != value) { fuelType = value; OnPropertyChanged(nameof(FuelType)); } }
        }

        public int Gearbox
        {
            get => gearbox;
            set { if (gearbox != value) { gearbox = value; OnPropertyChanged(nameof(Gearbox)); } }
        }

        public string VehicleClass
        {
            get => vehicleClass;
            set { if (vehicleClass != value) { vehicleClass = value; OnPropertyChanged(nameof(VehicleClass)); } }
        }

        public string Color
        {
            get => color;
            set { if (color != value) { color = value; OnPropertyChanged(nameof(Color)); } }
        }

        public int Mileage
        {
            get => mileage;
            set { if (mileage != value) { mileage = value; OnPropertyChanged(nameof(Mileage)); } }
        }

        public int StatusCar
        {
            get => statusCar;
            set { if (statusCar != value) { statusCar = value; OnPropertyChanged(nameof(StatusCar)); } }
        }

        public float DailyPrice_1_3
        {
            get => dailyPrice_1_3;
            set { if (dailyPrice_1_3 != value) { dailyPrice_1_3 = value; OnPropertyChanged(nameof(DailyPrice_1_3)); } }
        }

        public float DailyPrice_4_8
        {
            get => dailyPrice_4_8;
            set { if (dailyPrice_4_8 != value) { dailyPrice_4_8 = value; OnPropertyChanged(nameof(DailyPrice_4_8)); } }
        }

        public float DailyPrice_9_15
        {
            get => dailyPrice_9_15;
            set { if (dailyPrice_9_15 != value) { dailyPrice_9_15 = value; OnPropertyChanged(nameof(DailyPrice_9_15)); } }
        }

        public float DailyPrice_16_29
        {
            get => dailyPrice_16_29;
            set { if (dailyPrice_16_29 != value) { dailyPrice_16_29 = value; OnPropertyChanged(nameof(DailyPrice_16_29)); } }
        }

        public float DailyPrice_30plus
        {
            get => dailyPrice_30plus;
            set { if (dailyPrice_30plus != value) { dailyPrice_30plus = value; OnPropertyChanged(nameof(DailyPrice_30plus)); } }
        }

        public float WeekendPrice
        {
            get => weekendPrice;
            set { if (weekendPrice != value) { weekendPrice = value; OnPropertyChanged(nameof(WeekendPrice)); } }
        }

        public float Deposit
        {
            get => deposit;
            set { if (deposit != value) { deposit = value; OnPropertyChanged(nameof(Deposit)); } }
        }

        public string ImagePath
        {
            get => imagePath;
            set { if (imagePath != value) { imagePath = value; OnPropertyChanged(nameof(ImagePath)); } }
        }

        // Event dla WPF powiadamiania o zmianach
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
