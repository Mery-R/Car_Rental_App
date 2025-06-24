using Car_Rental.Repositories;
using System;
using System.Windows;
using Car_Rental.Models;

namespace Car_Rental
{
    /// <summary>
    /// Klasa App dziedziczy po Application i odpowiada za cykl życia aplikacji WPF.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Statyczna właściwość przechowująca aktualnie zalogowanego użytkownika.
        /// </summary>
        public static UserModel CurrentUser { get; set; }

        /// <summary>
        /// Konstruktor aplikacji. Inicjalizuje bazę danych użytkowników przy starcie aplikacji.
        /// </summary>
        public App()
        {
            // Inicjalizacja bazy danych przy starcie aplikacji
            DatabaseInitializer.InitializeDatabase(); // Tworzenie bazy i tabeli
        }
    }
}
