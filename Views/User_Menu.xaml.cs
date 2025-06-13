// Plik: User_Menu.xaml.cs
// Przeznaczenie: Okno menu użytkownika. Umożliwia dostęp do przeglądania pojazdów, historii wypożyczeń oraz wylogowania.

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
    /// Klasa User_Menu odpowiada za logikę menu użytkownika.
    /// </summary>
    public partial class User_Menu : Window
    {
        /// <summary>
        /// Konstruktor inicjalizujący komponenty okna menu użytkownika.
        /// </summary>
        public User_Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługuje wyświetlanie dostępnych pojazdów.
        /// </summary>
        private void ShowVehicles_Click(object sender, RoutedEventArgs e)
        {
           //
        }

        /// <summary>
        /// Obsługuje wyświetlanie historii wypożyczeń.
        /// </summary>
        private void History_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        /// <summary>
        /// Obsługuje wylogowanie użytkownika.
        /// </summary>
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
