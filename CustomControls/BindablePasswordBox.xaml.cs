using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Car_Rental.CustomControls
{
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(BindablePasswordBox));

        public static readonly DependencyProperty PlainTextPasswordProperty =
            DependencyProperty.Register(nameof(PlainTextPassword), typeof(string), typeof(BindablePasswordBox));

        public SecureString Password
        {
            get => (SecureString)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public string PlainTextPassword
        {
            get => (string)GetValue(PlainTextPasswordProperty);
            set => SetValue(PlainTextPasswordProperty, value);
        }

        private bool isPasswordVisible = false;

        public BindablePasswordBox()
        {
            InitializeComponent();
            txtPassword.PasswordChanged += TxtPassword_PasswordChanged;
            passwordTxtBox.TextChanged += PasswordTxtBox_TextChanged;
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!isPasswordVisible)
            {
                // aktualizuj tylko, gdy widoczność ukryta
                PlainTextPassword = txtPassword.Password;
                Password = txtPassword.SecurePassword;
            }
        }

        private void PasswordTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isPasswordVisible)
            {
                // aktualizuj tylko, gdy widoczność pokazana
                PlainTextPassword = passwordTxtBox.Text;

                var secure = new SecureString();
                foreach (char c in passwordTxtBox.Text)
                    secure.AppendChar(c);
                secure.MakeReadOnly();

                Password = secure;
                txtPassword.Password = passwordTxtBox.Text; // synchronizacja ukrytego PasswordBox
            }
        }

        private void ToggleImageButton_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                ToggleImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye_open.png"));
                passwordTxtBox.Text = txtPassword.Password; // sync
                txtPassword.Visibility = Visibility.Collapsed;
                passwordTxtBox.Visibility = Visibility.Visible;
                passwordTxtBox.Focus();
                passwordTxtBox.CaretIndex = passwordTxtBox.Text.Length;
            }
            else
            {
                ToggleImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye_closed.png"));
                txtPassword.Password = passwordTxtBox.Text; // sync
                passwordTxtBox.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Focus();
            }
        }
    }
}
