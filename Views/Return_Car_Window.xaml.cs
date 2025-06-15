using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Car_Rental.Views
{
    public partial class Return_Car_Window : Window
    {
        private readonly CarModel _car;
        private readonly CustomerModel _customer;
        private readonly ReservationModel _reservation;

        private List<DamageModel> damages = new List<DamageModel>();

        private Canvas currentCanvas;
        private string currentSide;
        private Point lastClickPosition;
        public Return_Car_Window(CarModel car, CustomerModel customer, ReservationModel reservation)
        {
            InitializeComponent();
            _car = car;
            _customer = customer;
            _reservation = reservation;

            CarDetailsText.Text = $"{car.Brand} {car.Model} | {car.LicensePlate}";
            CustomerText.Text = $"{customer.FullName}";
            MileageTextBox.Text = car.Mileage.ToString();

            RefreshDateTime();

            // Załaduj uszkodzenia z bazy i dodaj je do canvasu
            var damageRepo = new DamageRepository();
            damageRepo.LoadCarDamages(currentCanvas, car.CarId);
        }


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            currentCanvas = image.Parent as Canvas;

            // Pobierz klikniętą stronę
            currentSide = ((TabItem)((TabControl)ImageTabs).SelectedItem).Header.ToString();
            lastClickPosition = e.GetPosition(currentCanvas);

            DamageTypeComboBox.SelectedIndex = 0;
            DamageNoteTextBox.Text = "";
            DamagePopup.IsOpen = true;
        }

        private void AddDamage_Click(object sender, RoutedEventArgs e)
        {
            if (DamageTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                // Sprawdzamy, czy udało się sparsować typ uszkodzenia
                var damageTypeString = selectedItem.Content.ToString();

                if (Enum.TryParse<DamageType>(damageTypeString, out var parsedType))
                {
                    var damage = new DamageModel
                    {
                        CarId = _car.CarId,
                        Side = currentSide,
                        X = lastClickPosition.X,
                        Y = lastClickPosition.Y,
                        Type = parsedType,
                        Note = DamageNoteTextBox.Text
                    };

                    // Dodajemy uszkodzenie do listy
                    damages.Add(damage);

                    // Dodajemy marker na canvas
                    AddMarkerToCanvas(currentCanvas, damage);

                    // Zapisujemy uszkodzenie w bazie
                    var damageRepo = new DamageRepository();
                    damageRepo.AddDamage(damage);

                    DamagePopup.IsOpen = false;
                }
                else
                {
                    MessageBox.Show("Unknown damage type selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }





        private void AddMarkerToCanvas(Canvas canvas, DamageModel damage)
        {
            var damageRepo = new DamageRepository();
            var marker = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = damageRepo.GetColorByDamageType(damage.Type),
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                ToolTip = $"{damage.Type}: {damage.Note}"
            };

            Canvas.SetLeft(marker, damage.X - 5);
            Canvas.SetTop(marker, damage.Y - 5);
            canvas.Children.Add(marker);
        }



        private void RefreshDateTime()
        {
            CurrentDateTimeText.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void RefreshDateTime_Click(object sender, RoutedEventArgs e)
        {
            RefreshDateTime();
        }

        private void ConfirmReturn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(MileageTextBox.Text, out int newMileage) || newMileage < _car.Mileage)
            {
                MessageBox.Show("Invalid mileage value.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _car.Mileage = newMileage;
            _car.StatusCar = (int)CarStatus.Available;

            var carRepo = new CarRepository();
            carRepo.UpdateCar(_car);

            _reservation.StatusReservation = (int)ReservationStatus.Finished;
            var resRepo = new ReservationRepository();
            resRepo.UpdateReservation(_reservation); // Dodaj tę metodę w repozytorium

            MessageBox.Show("Car returned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }
    }
}
