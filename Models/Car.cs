using System.ComponentModel;

namespace Car_Rental.Models
{
    public class Car : INotifyPropertyChanged
    {
        private int id;
        private string brand;
        private string model;
        private int productionYear;
        private string plateNumber;
        private bool availability;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Brand
        {
            get { return brand; }
            set
            {
                if (brand != value)
                {
                    brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public int ProductionYear
        {
            get { return productionYear; }
            set
            {
                if (productionYear != value)
                {
                    productionYear = value;
                    OnPropertyChanged(nameof(ProductionYear));
                }
            }
        }

        public string PlateNumber
        {
            get { return plateNumber; }
            set
            {
                if (plateNumber != value)
                {
                    plateNumber = value;
                    OnPropertyChanged(nameof(PlateNumber));
                }
            }
        }

        public bool Availability
        {
            get { return availability; }
            set
            {
                if (availability != value)
                {
                    availability = value;
                    OnPropertyChanged(nameof(Availability));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Konstruktor z parametrem Id
        public Car(int id, string brand, string model, int productionYear, string plateNumber, bool availability)
        {
            this.Id = id;
            this.Brand = brand;
            this.Model = model;
            this.ProductionYear = productionYear;
            this.PlateNumber = plateNumber;
            this.Availability = availability;
        }
    }
}