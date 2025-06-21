// Plik: User_Menu.xaml.cs
// Przeznaczenie: Okno menu użytkownika. Umożliwia dostęp do przeglądania pojazdów, historii wypożyczeń oraz wylogowania.

using Car_Rental.Models;
using Car_Rental.ViewModels;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Car_Rental.Views
{
    /// <summary>
    /// Klasa User_Menu odpowiada za logikę menu użytkownika.
    /// </summary>
    public partial class User_Menu : Window
    {
        public UserAccountModel CurrentUserAccount { get; set; }
        
        public User_Menu()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            CurrentUserAccount = new UserAccountModel
            {
                Username = "user",
                DisplayName = "Użytkownik"
            };

            this.DataContext = new MainViewModel();
            this.SourceInitialized += User_Menu_SourceInitialized;
        }

        // Wylogowanie
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginScreen = new MainWindow();
            loginScreen.Show();
            this.Close();
        }

        // Obsługa przycisku minimalizacji
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Obsługa przycisku maksymalizacji
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal
                ? WindowState.Maximized
                : WindowState.Normal;
        }

        // Obsługa przycisku zamknięcia
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Przeciąganie okna
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void User_Menu_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(handle);
            if (hwndSource != null)
                hwndSource.AddHook(WindowProc);
        }

        // Resize logika
        private const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12,
                          HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15,
                          HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17;

        private const int WM_NCHITTEST = 0x0084;
        private const int RESIZE_HANDLE_SIZE = 8;

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST)
            {
                handled = true;
                Point mousePos = GetMousePosition(lParam);

                GetWindowRect(hwnd, out RECT windowRect);
                Rect rect = new Rect(windowRect.Left, windowRect.Top,
                                     windowRect.Right - windowRect.Left,
                                     windowRect.Bottom - windowRect.Top);

                if (mousePos.Y >= rect.Top && mousePos.Y <= rect.Top + RESIZE_HANDLE_SIZE)
                {
                    if (mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTTOPLEFT;
                    if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTTOPRIGHT;
                    return (IntPtr)HTTOP;
                }

                if (mousePos.Y >= rect.Bottom - RESIZE_HANDLE_SIZE)
                {
                    if (mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTBOTTOMLEFT;
                    if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE)
                        return (IntPtr)HTBOTTOMRIGHT;
                    return (IntPtr)HTBOTTOM;
                }

                if (mousePos.X <= rect.Left + RESIZE_HANDLE_SIZE)
                    return (IntPtr)HTLEFT;
                if (mousePos.X >= rect.Right - RESIZE_HANDLE_SIZE)
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
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X, Y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        private Point GetMousePosition(IntPtr lParam)
        {
            GetCursorPos(out POINT pt);
            return new Point(pt.X, pt.Y);
        }
    }
}
