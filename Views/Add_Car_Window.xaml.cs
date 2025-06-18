using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms; // Używaj tego tylko, jeśli musisz obsługiwać formularze Windows Forms (np. MessageBox)
using System.Windows.Input; // Dla DragEventArgs
using System.Windows.Media.Imaging;



namespace Car_Rental.Views
{
    public partial class Add_Car_Window : Window
    {
        public CarModel NewCar { get; private set; }
        private string _imagePath;
        private readonly CarRepository _carRepository = new CarRepository();


        public Add_Car_Window()
        {
            InitializeComponent();
            // Przypisanie wartości enumu do ComboBox
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(CarStatus));

            // Ustawienie domyślnej wartości (np. Available = 0)
            StatusComboBox.SelectedValue = CarStatus.Available;
            int startYear = 1886;
            int currentYear = DateTime.Now.Year;
            ProductionYearComboBox.ItemsSource = Enumerable.Range(startYear, currentYear - startYear + 1).Reverse();
        }


        private void ImageDropZone_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    string filePath = files[0];
                    _imagePath = filePath;

                    try
                    {
                        var image = new BitmapImage(new Uri(filePath));
                        PreviewImage.Source = image;
                        PreviewImage.Visibility = Visibility.Visible;
                        DropHintText.Visibility = Visibility.Collapsed;
                        ImageInfoText.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Nie można wczytać obrazu: " + ex.Message);
                    }
                }
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Sprawdzamy, czy wymagane pola zostały wypełnione
                if (string.IsNullOrEmpty(BrandComboBox.SelectedItem?.ToString()) ||
                    string.IsNullOrEmpty(ModelTextBox.Text) ||
                    ProductionYearComboBox.SelectedItem == null ||
                    string.IsNullOrEmpty(LicensePlateTextBox.Text) ||
                    StatusComboBox.SelectedItem == null)
                {
                    System.Windows.MessageBox.Show("Wszystkie wymagane pola muszą być wypełnione: Brand, Model, Year, LicensePlate, Status.");
                    return;
                }

                NewCar = new CarModel
                {
                    Brand = BrandComboBox.SelectedItem != null ? BrandComboBox.SelectedItem.ToString() : string.Empty,
                    Model = string.IsNullOrEmpty(ModelTextBox.Text) ? string.Empty : ModelTextBox.Text,
                    ProductionYear = ProductionYearComboBox.SelectedItem != null ? (int)ProductionYearComboBox.SelectedItem : 0,
                    LicensePlate = string.IsNullOrEmpty(LicensePlateTextBox.Text) ? string.Empty : LicensePlateTextBox.Text,
                    VIN = string.IsNullOrEmpty(VINTextBox.Text) ? string.Empty : VINTextBox.Text,
                    Engine = string.IsNullOrEmpty(EngineTextBox.Text) ? string.Empty : EngineTextBox.Text,
                    FuelType = FuelTypeComboBox.SelectedItem != null ? (int)(FuelType)FuelTypeComboBox.SelectedItem : 0,
                    Gearbox = GearboxComboBox.SelectedItem != null ? (int)(Gearbox)GearboxComboBox.SelectedItem : 0,
                    VehicleClass = string.IsNullOrEmpty(VehicleClassComboBox.SelectedItem?.ToString()) ? string.Empty : VehicleClassComboBox.SelectedItem.ToString(),
                    Color = string.IsNullOrEmpty(ColorComboBox.SelectedItem?.ToString()) ? string.Empty : ColorComboBox.SelectedItem.ToString(),
                    Mileage = string.IsNullOrEmpty(MileageTextBox.Text) ? 0 : int.Parse(MileageTextBox.Text),
                    StatusCar = StatusComboBox.SelectedItem != null ? (int)(CarStatus)StatusComboBox.SelectedItem : 0,
                    DailyPrice_1_3 = string.IsNullOrEmpty(DailyPrice13TextBox.Text) ? 0f : float.Parse(DailyPrice13TextBox.Text),
                    DailyPrice_4_8 = string.IsNullOrEmpty(DailyPrice48TextBox.Text) ? 0f : float.Parse(DailyPrice48TextBox.Text),
                    DailyPrice_9_15 = string.IsNullOrEmpty(DailyPrice915TextBox.Text) ? 0f : float.Parse(DailyPrice915TextBox.Text),
                    DailyPrice_16_29 = string.IsNullOrEmpty(DailyPrice1629TextBox.Text) ? 0f : float.Parse(DailyPrice1629TextBox.Text),
                    DailyPrice_30plus = string.IsNullOrEmpty(DailyPrice30PlusTextBox.Text) ? 0f : float.Parse(DailyPrice30PlusTextBox.Text),
                    WeekendPrice = string.IsNullOrEmpty(WeekendPriceTextBox.Text) ? 0f : float.Parse(WeekendPriceTextBox.Text),
                    Deposit = string.IsNullOrEmpty(DepositTextBox.Text) ? 0f : float.Parse(DepositTextBox.Text),
                    ImagePath = string.IsNullOrEmpty(_imagePath) ? string.Empty : _imagePath
                };

                var carRepository = new CarRepository();  // Używa domyślnej metody GetConnection z RepositoryBase
                carRepository.AddCar(NewCar);  // Zapisz zaktualizowany samochód


                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Błąd podczas zapisu: " + ex.Message);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}