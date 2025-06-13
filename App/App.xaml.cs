// Plik: App.xaml.cs
// Przeznaczenie: Główny plik klasy aplikacji WPF. Odpowiada za inicjalizację aplikacji Car_Rental, w tym za startowe przygotowanie bazy danych użytkowników.
// Autor: (uzupełnij według potrzeb)
// Data utworzenia: (uzupełnij według potrzeb)

using Car_Rental.Repositories;
using System;
using System.Windows;

namespace Car_Rental
{
    /// <summary>
    /// Klasa App dziedziczy po Application i odpowiada za cykl życia aplikacji WPF.
    /// </summary>
    public partial class App : Application
    {
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
