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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Car_Rental.Views
{
    public partial class Return_Car_Window : Window
    {
        private readonly CarModel _car;
        private readonly CustomerModel _customer;
        private ReservationModel _reservation;

        private readonly DamageRepository _damageRepository;
        private readonly List<DamageModel> _allDamages;
        private List<ReservationModel> _reservations = new List<ReservationModel>();

        private readonly ReservationRepository _reservationRepository = new ReservationRepository();

        private int _carId; // ustawiane z zewnątrz!

        private Point _lastClickPosition;
        private int _currentSide;

        public Return_Car_Window(CarModel car, CustomerModel customer, ReservationModel reservation)
        {
            InitializeComponent();
            // ustawienie domyślnego indeksu zakładki na 0 (przód samochodu)
            ImageTabs.SelectedIndex = 0;

            _car = car;
            _customer = customer;
            _reservation = reservation;

            // initialize repository and load damages
            _damageRepository = new DamageRepository();
            _allDamages = _damageRepository.GetDamagesByCarId(_car.CarId);

            LoadCarDamages(FrontCanvas, _allDamages, 0);
            LoadCarDamages(BackCanvas, _allDamages, 1);
            LoadCarDamages(LeftCanvas, _allDamages, 2);
            LoadCarDamages(RightCanvas, _allDamages, 3);

            // setup UI
            CarDetailsText.Text = $"{car.Brand} {car.Model} | {car.LicensePlate}";
            CustomerText.Text = $"{customer.FullName}";
            MileageTextBox.Text = car.Mileage.ToString();
            RefreshDateTime();

            ImageTabs.SelectionChanged += ImageTabs_SelectionChanged;

            var resRepo = new ReservationRepository();
            _reservations = resRepo.GetActiveReservationsByCarId(car.CarId);

            ReservationComboBox.ItemsSource = _reservations;
            Console.WriteLine("CarID: " + car.CarId);

            System.Diagnostics.Debug.WriteLine($"Found {_reservations.Count} active reservations");

            if (_reservations.Count > 0)
            {
                ReservationComboBox.SelectedIndex = 0;  // ustaw domyślnie pierwszy element
                ShowReservationDetails(_reservations[0]); // wyświetl szczegóły od razu
            }
        }
        // Metoda, która wczytuje uszkodzenia i dodaje markery na canvasie
        public void LoadCarDamages(Canvas canvas, List<DamageModel> damages, int side)
        {

            foreach (var damage in damages)
            {
                if (damage.Side != side)
                    continue;

                var marker = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = GetColorByDamageType(damage.Type),
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    ToolTip = $"{damage.Type}: {damage.Note}"
                };

                Canvas.SetLeft(marker, damage.X - 5);
                Canvas.SetTop(marker, damage.Y - 5);
                canvas.Children.Add(marker);
            }
        }
        // Metoda pomocnicza do pobrania koloru na podstawie typu uszkodzenia
        public Brush GetColorByDamageType(DamageType type)
        {
            switch (type)
            {
                case DamageType.Scratch: return Brushes.Orange;
                case DamageType.Dent: return Brushes.Red;
                case DamageType.Chip: return Brushes.Purple;
                case DamageType.Crack: return Brushes.Blue;
                default: return Brushes.Gray;
            }
        }
        private void ImageTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var tab = ImageTabs.SelectedIndex;
            DisplayDamagesForSide(tab);
        }

        private void DisplayDamagesForSide(int tab)
        {
            Canvas canvas = null;
            if (tab == 0) canvas = FrontCanvas;
            else if (tab == 1) canvas = BackCanvas;
            else if (tab == 2) canvas = LeftCanvas;
            else if (tab == 3) canvas = RightCanvas;

            if (canvas == null) return;

            foreach (var damage in _allDamages)
            {
                System.Diagnostics.Debug.WriteLine($"Damage: Side={damage.Side}, X={damage.X}, Y={damage.Y}");
                if (damage.Side != tab) continue;

                var marker = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = GetColorByDamageType(damage.Type),
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    ToolTip = string.Format("{0}: {1}", damage.Type, damage.Note)
                };
                Canvas.SetLeft(marker, damage.X - 5);
                Canvas.SetTop(marker, damage.Y - 5);
                canvas.Children.Add(marker);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            var canvas = image?.Parent as Canvas;
            if (canvas == null) return;

            _lastClickPosition = e.GetPosition(canvas);
            _currentSide = ImageTabs.SelectedIndex;

            DamageTypeComboBox.SelectedIndex = 0;
            DamageNoteTextBox.Clear();
            DamagePopup.IsOpen = true;
        }

        private void AddDamage_Click(object sender, RoutedEventArgs e)
        {
            if (!(DamageTypeComboBox.SelectedItem is ComboBoxItem item)) return;
            if (!Enum.TryParse<DamageType>(item.Content.ToString(), out var type))
            {
                MessageBox.Show("Unknown damage type.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newDamage = new DamageModel
            {
                CarId = _car.CarId,
                ReservationId = _reservation?.ReservationId,
                Side = _currentSide,
                X = _lastClickPosition.X,
                Y = _lastClickPosition.Y,
                Type = type,
                Note = DamageNoteTextBox.Text
            };
            _damageRepository.AddDamage(newDamage);
            _allDamages.Add(newDamage);
            DisplayDamagesForSide(_currentSide);
            DamagePopup.IsOpen = false;
        }

        private void ConfirmReturn_Click(object sender, RoutedEventArgs e)
        {
            if (_reservation == null)
            {
                MessageBox.Show("No reservation selected.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!int.TryParse(MileageTextBox.Text, out var newMileage) || newMileage < _car.Mileage)
            {
                MessageBox.Show("Invalid mileage.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _car.Mileage = newMileage;
            _reservation.StatusReservation = (int)ReservationStatus.Finished;
            new ReservationRepository().UpdateReservation(_reservation);

            var active = new ReservationRepository()
                .GetActiveReservationsByCarId(_car.CarId)
                .Where(r => r.StatusReservation != (int)ReservationStatus.Finished);

            _car.StatusCar = !active.Any()
                ? (int)CarStatus.Available
                : active.Any(r => r.StatusReservation == (int)ReservationStatus.Active)
                    ? (int)CarStatus.Rented
                    : (int)CarStatus.Reserved;
            new CarRepository().UpdateCar(_car);

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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;  // zwracasz false do kodu wywołującego
            Close();               // zamykasz okno
        }


        private void RefreshDateTime_Click(object sender, RoutedEventArgs e) => RefreshDateTime();
        private void RefreshDateTime() => CurrentDateTimeText.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}