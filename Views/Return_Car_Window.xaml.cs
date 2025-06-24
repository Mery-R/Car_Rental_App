using Car_Rental.Models;
using Car_Rental.Repositories;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (GeneratePdfCheckBox.IsChecked == true)
            {
                // Pobieramy dane klienta i rezerwacji z pola _reservation
                string customerName = _reservation.CustomerFullName;

                // Szczegóły auta z pola _car (lub z pola tekstowego, jeśli wolisz)
                string carDetails = $"{_car.Brand} {_car.Model} | Reg: {_car.LicensePlate}";

                // Okres wypożyczenia: od daty rozpoczęcia rezerwacji do momentu zwrotu
                string rentalPeriod = string.Format(
                    "{0:yyyy-MM-dd} to {1:yyyy-MM-dd}",
                    _reservation.StartDate,
                    DateTime.Now);

                // Całkowita cena z rezerwacji
                float totalPrice = _reservation.TotalPrice;

                // Wpłacona kaucja z modelu auta
                float deposit = _car.Deposit;

                GeneratePdfAgreement(customerName, carDetails, rentalPeriod, totalPrice, deposit);
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

        private void GeneratePdfAgreement(
    string customerName,
    string carDetails,
    string rentalPeriod,
    float totalPrice,
    float deposit)
        {
            // 1) Przygotowanie katalogu i nazwy pliku
            string folder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Invoices_Return");
            Directory.CreateDirectory(folder);

            string fileName = $"Return_{customerName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string filePath = System.IO.Path.Combine(folder, fileName);

            // 2) Utworzenie dokumentu i strony A4
            var document = new PdfDocument();
            var page = document.AddPage();
            page.Width = 595;  // szerokość A4 w punktach
            page.Height = 842;  // wysokość A4
            var gfx = XGraphics.FromPdfPage(page);

            // 3) Czcionki
            var headerFont = new XFont("Verdana", 16);
            var font = new XFont("Verdana", 12);

            // 4) Rysowanie nagłówka i informacji tekstowych
            double y = 40;
            gfx.DrawString("Car Return Report", headerFont, XBrushes.Black, 40, y); y += 30;
            gfx.DrawString($"Customer: {customerName}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Car: {carDetails}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Period: {rentalPeriod}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Total Price: {totalPrice:C}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Deposit: {deposit:C}", font, XBrushes.Black, 40, y); y += 30;

            // 5) Definicje obrazków i ich rozmiarów
            var sides = new[] { "front.jpg", "back.jpg", "left.png", "right.png" };
            var sizes = new (double W, double H)[]
            {
            (200, 180), // front
            (160, 160), // back
            (250, 150), // left
            (250, 150)  // right
            };
            // offset kropek per side
            var offsets = new (double X, double Y)[]
            {
            (  0, -5),   // front
            (  0,  5),   // back
            (  0,-15),   // left
            (  0,-15)    // right
            };

            double startX = 40;
            double startY = y;

            // 6) Rysowanie każdego obrazka + kropek
            for (int i = 0; i < sides.Length; i++)
            {
                string imgFile = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Images", sides[i]);
                if (!File.Exists(imgFile))
                    continue;  // pomiń jeżeli brak pliku

                // wymiary dla tego boku
                double imgW = sizes[i].W;
                double imgH = sizes[i].H;

                // pozycja w układzie 2×2 (możesz dostosować grid)
                double xPos = startX + (i % 2) * (imgW + 20);
                double yPos = startY + (i / 2) * (imgH + 40);

                // wczytanie i narysowanie obrazka
                var img = XImage.FromFile(imgFile);
                gfx.DrawImage(img, xPos, yPos, imgW, imgH);

                // rysowanie kropek
                var damagesForSide = _allDamages.Where(d => d.Side == i);
                foreach (var d in damagesForSide)
                {
                    // wybór koloru wg typu
                    XColor dotColor;
                    switch (d.Type)
                    {
                        case DamageType.Scratch: dotColor = XColors.Orange; break;
                        case DamageType.Dent: dotColor = XColors.Red; break;
                        case DamageType.Chip: dotColor = XColors.Purple; break;
                        case DamageType.Crack: dotColor = XColors.Blue; break;
                        default: dotColor = XColors.Gray; break;
                    }

                    // 2) Podstawowe relX/relY ze skalowania Canvas→PDF
                    double relX = xPos + (d.X / FrontCanvas.ActualWidth) * imgW;
                    double relY = yPos + (d.Y / FrontCanvas.ActualHeight) * imgH;

                    // 3) Oblicz środek obrazka:
                    double centerX = xPos + imgW / 2;
                    double centerY = yPos + imgH / 2;

                    // 4) Wyciągnij wektor od środka:
                    double dx = relX - centerX;
                    double dy = relY - centerY;

                    // 5) Rozsunięcie wzdłuż promienia:
                    double spread = 1.0;          // 1.0 = bez zmiany, >1 = odsunięcie od środka
                    relX = centerX + dx * spread;
                    relY = centerY + dy * spread;

                    // 6) (opcjonalnie) offset per side dalej:
                    relX += offsets[i].X;
                    relY += offsets[i].Y;

                    // rysowanie kropki (dotSize stałe)
                    double dotSize = 8;
                    var brush = new XSolidBrush(dotColor);
                    var pen = new XPen(dotColor, 1);
                    gfx.DrawEllipse(
                        pen, brush,
                        relX - dotSize / 2,
                        relY - dotSize / 2,
                        dotSize,
                        dotSize);
                }
            }

            // 7) Zapis pliku
            document.Save(filePath);
        }


    }
}