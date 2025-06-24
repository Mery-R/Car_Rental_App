using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Car_Rental.Views
{
    public partial class Return_Car_Window : Window
    {
        private readonly CarModel _car;
        private readonly CustomerModel _customer;

        private List<DamageModel> damages = new List<DamageModel>();

        private Canvas currentCanvas;
        private string currentSide;
        private Point lastClickPosition;

        private readonly ReservationRepository _reservationRepository = new ReservationRepository();
        private List<ReservationModel> _reservations = new List<ReservationModel>();
        private int _carId; // ustawiane z zewnątrz!
        private ReservationModel _reservation;



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

            var resRepo = new ReservationRepository();
            _reservations = resRepo.GetActiveReservationsByCarId(car.CarId);

            ReservationComboBox.ItemsSource = _reservations;

            if (_reservations.Count > 0)
            {
                ReservationComboBox.SelectedIndex = 0;  // ustaw domyślnie pierwszy element
                ShowReservationDetails(_reservations[0]); // wyświetl szczegóły od razu
            }
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
            if (_reservation == null)
            {
                MessageBox.Show("No reservation selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(MileageTextBox.Text, out int newMileage) || newMileage < _car.Mileage)
            {
                MessageBox.Show("Invalid mileage value.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Aktualizacja przebiegu
            _car.Mileage = newMileage;

            // Oznacz wybraną rezerwację jako zakończoną
            _reservation.StatusReservation = (int)ReservationStatus.Finished;

            var resRepo = new ReservationRepository();
            resRepo.UpdateReservation(_reservation);

            // Sprawdź, czy są jeszcze inne aktywne rezerwacje (o statusie Reserved lub Rented)
            var activeReservations = resRepo.GetActiveReservationsByCarId(_car.CarId)
                                            .Where(r => r.StatusReservation != (int)ReservationStatus.Finished)
                                            .ToList();

            // Ustaw status auta na podstawie tego, czy są inne aktywne rezerwacje
            if (activeReservations.Count == 0)
            {
                _car.StatusCar = (int)CarStatus.Available;
            }
            else
            {
                // Sprawdź, czy któraś z rezerwacji jest aktualnie wypożyczona
                bool isRented = activeReservations.Any(r => r.StatusReservation == (int)ReservationStatus.Active);
                _car.StatusCar = isRented ? (int)CarStatus.Rented : (int)CarStatus.Reserved;
            }

            var carRepo = new CarRepository();
            carRepo.UpdateCar(_car);

            MessageBox.Show("Car returned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }




        private void ReservationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationComboBox.SelectedItem is ReservationModel selectedReservation)
            {
                _reservation = selectedReservation; // aktualizacja pola _reservation
                ShowReservationDetails(selectedReservation);
            }
            else
            {
                _reservation = null;
                CarDetailsText.Text = "";
                CustomerText.Text = "";
            }
        }



        private void ShowReservationDetails(ReservationModel selectedReservation)
        {
            CarDetailsText.Text = $"Marka: {selectedReservation.CarBrand}, Model: {selectedReservation.CarModel}, Rok: {selectedReservation.CarYear}, Rejestracja: {selectedReservation.LicensePlate}";

            CustomerText.Text = $"Klient: {selectedReservation.CustomerFullName}\nPESEL: {selectedReservation.CustomerPESEL}";

        }


    }
}
