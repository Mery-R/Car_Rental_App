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

            this.SourceInitialized += Admin_Menu_SourceInitialized;
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

        private void Admin_Menu_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(handle);
            if (hwndSource != null)
                hwndSource.AddHook(WindowProc);
        }

        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        private const int WM_NCHITTEST = 0x0084;

        private const int RESIZE_HANDLE_SIZE = 8;

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST)
            {
                handled = true;

                Point mousePos = GetMousePosition(lParam);

                // Pobieramy prostokąt okna w screen coordinates — za pomocą WinAPI
                RECT windowRect;
                GetWindowRect(hwnd, out windowRect);

                // Konwersja RECT do Rect
                Rect rect = new Rect(windowRect.Left, windowRect.Top,
                                     windowRect.Right - windowRect.Left,
                                     windowRect.Bottom - windowRect.Top);

                // Dalej twoja logika z rect zamiast PointToScreen i ActualWidth/Height
                if (mousePos.Y >= rect.Top && mousePos.Y <= rect.Top + RESIZE_HANDLE_SIZE)
                {
                    if (mousePos.X >= rect.Left && mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTTOPLEFT;
                    if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE && mousePos.X <= rect.Right)
                        return (IntPtr)HTTOPRIGHT;
                    return (IntPtr)HTTOP;
                }

                if (mousePos.Y >= rect.Bottom - RESIZE_HANDLE_SIZE && mousePos.Y <= rect.Bottom)
                {
                    if (mousePos.X >= rect.Left && mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTBOTTOMLEFT;
                    if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE && mousePos.X <= rect.Right)
                        return (IntPtr)HTBOTTOMRIGHT;
                    return (IntPtr)HTBOTTOM;
                }

                if (mousePos.X >= rect.Left && mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                    return (IntPtr)HTLEFT;

                if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE && mousePos.X <= rect.Right)
                    return (IntPtr)HTRIGHT;

                return (IntPtr)1; // HTCLIENT
            }

            return IntPtr.Zero;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        private Point GetMousePosition(IntPtr lParam)
        {
            // Najprostsza i stabilna metoda - wyciągnij aktualną pozycję kursora
            GetCursorPos(out POINT pt);
            return new Point(pt.X, pt.Y);
        }
    }
}
