using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Car_Rental
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Inicjalizacja bazy danych przy starcie aplikacji
            var userRepository = new UserRepository();
            userRepository.InitializeDatabase(); // Tworzenie bazy i tabeli
        }
    }
}
