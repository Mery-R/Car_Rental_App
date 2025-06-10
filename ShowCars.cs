using System.Collections.Generic;
using System.Windows;

namespace Car_Rental
{
    public partial class ShowCars : Window
    {
        public ShowCars()
        {
            InitializeComponent();
            CarsDataGrid.ItemsSource = GetSampleCars();
        }

        public class Car
        {
            public string Marka { get; set; }
            public string Model { get; set; }
            public int RokProdukcji { get; set; }
            public string Rejestracja { get; set; }
            public string Dostepnosc { get; set; }
        }

        private List<Car> GetSampleCars()
        {
            return new List<Car>
            {
                new Car { Marka = "Toyota", Model = "Corolla", RokProdukcji = 2018, Rejestracja = "KR12345", Dostepnosc = "Dost�pny" },
                new Car { Marka = "Ford", Model = "Focus", RokProdukcji = 2020, Rejestracja = "WA54321", Dostepnosc = "Niedost�pny" },
                new Car { Marka = "Volkswagen", Model = "Golf", RokProdukcji = 2019, Rejestracja = "PO98765", Dostepnosc = "Dost�pny" },
                new Car { Marka = "Opel", Model = "Astra", RokProdukcji = 2017, Rejestracja = "LU11223", Dostepnosc = "Dost�pny" },
                new Car { Marka = "Renault", Model = "Megane", RokProdukcji = 2016, Rejestracja = "GD44556", Dostepnosc = "Niedost�pny" },
                new Car { Marka = "Skoda", Model = "Octavia", RokProdukcji = 2021, Rejestracja = "SZ77889", Dostepnosc = "Dost�pny" },
                new Car { Marka = "Peugeot", Model = "308", RokProdukcji = 2015, Rejestracja = "KT33445", Dostepnosc = "Dost�pny" },
                new Car { Marka = "Mazda", Model = "3", RokProdukcji = 2018, Rejestracja = "KR55667", Dostepnosc = "Niedost�pny" }
            };
        }
    }
}