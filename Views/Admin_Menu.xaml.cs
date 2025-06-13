// Plik: Admin_Menu.xaml.cs
// Przeznaczenie: Okno menu administratora. Umożliwia dostęp do funkcji zarządzania flotą, wypożyczeń, raportów i wylogowania.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Rental.Views
{
    /// <summary>
    /// Klasa Admin_Menu odpowiada za logikę menu administratora.
    /// </summary>
    public partial class Admin_Menu : Window
    {
        /// <summary>
        /// Konstruktor inicjalizujący komponenty okna menu administratora.
        /// </summary>
        public Admin_Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Otwiera okno z listą samochodów i ukrywa bieżące okno.
        /// </summary>
        private void ShowCarsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Show_Cars_Window Show_Cars = new Show_Cars_Window();
            Show_Cars.Show();
        }

        /// <summary>
        /// Obsługuje logikę przycisku "Pick up a car".
        /// </summary>
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Pick up a car"
        }

        /// <summary>
        /// Obsługuje logikę przycisku "Manage fleet".
        /// </summary>
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Fleet_Management_Window manageWindow = new Fleet_Management_Window();
            manageWindow.Show();
        }

        /// <summary>
        /// Obsługuje logikę przycisku "Log out".
        /// </summary>
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Log out"
        }

        /// <summary>
        /// Obsługuje logikę przycisku "Rent a car".
        /// </summary>
        private void Button_Clic5(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Rent a car"
        }

        /// <summary>
        /// Obsługuje logikę przycisku "Raport".
        /// </summary>
        private void Button_Clic6(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki dla przycisku "Raport"
        }
    }
}
