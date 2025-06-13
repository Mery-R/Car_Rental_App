// Plik: Login_Screen.xaml.cs
// Przeznaczenie: Logika okna logowania użytkownika. Obsługuje zdarzenia związane z interfejsem logowania, takie jak zamykanie, minimalizowanie i przeciąganie okna.

using Car_Rental.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Car_Rental
{
    /// <summary>
    /// Klasa MainWindow odpowiada za logikę interakcji okna logowania.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor inicjalizujący komponenty okna logowania.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Username.Focus();
        }


        /// <summary>
        /// Pozwala na przeciąganie okna po ekranie po naciśnięciu lewego przycisku myszy.
        /// </summary>
        private void Login_Screen_Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Minimalizuje okno aplikacji.
        /// </summary>
        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Zamyka aplikację.
        /// </summary>
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
