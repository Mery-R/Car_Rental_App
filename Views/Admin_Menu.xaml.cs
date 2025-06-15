using Car_Rental.Models;
using Car_Rental.ViewModels;
using Car_Rental.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Rental.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_Menu.xaml
    /// </summary>
    public partial class Admin_Menu : Window
    {

        public UserAccountModel CurrentUserAccount { get; set; }
        public Admin_Menu()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; // Ustawienie maksymalnej wysokości okna

            CurrentUserAccount = new UserAccountModel
            {
                Username = "admin",
                DisplayName = "Admin"
            };

            this.DataContext = this;
            this.DataContext = new MainViewModel();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
           this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; // Ustawienie maksymalnej wysokości okna
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Zamknięcie okna
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
            
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginScreen = new MainWindow();
            loginScreen.Show();
            this.Close();
        }
    }
}
