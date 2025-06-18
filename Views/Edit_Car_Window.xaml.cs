using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Car_Rental.Views
{
    public partial class Edit_Car_Window : Window
    {
        public CarModel EditedCar { get; private set; }
        private string _imagePath;
        private int _carId;
        private readonly CarRepository _carRepository = new CarRepository();

        public Edit_Car_Window(CarModel car)
        {
            InitializeComponent();
            LoadEnumsAndYears();
            _carId = car.CarId;
            _imagePath = car.ImagePath;
            LoadCarData(car);
        }

        private void LoadEnumsAndYears()
        {
            BrandComboBox.ItemsSource = Enum.GetValues(typeof(Brand));
            FuelTypeComboBox.ItemsSource = Enum.GetValues(typeof(FuelType));
            GearboxComboBox.ItemsSource = Enum.GetValues(typeof(Gearbox));
            VehicleClassComboBox.ItemsSource = Enum.GetValues(typeof(VehicleClass));
            ColorComboBox.ItemsSource = Enum.GetValues(typeof(Color));
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(CarStatus));

            int startYear = 1886;
            int currentYear = DateTime.Now.Year;
            ProductionYearComboBox.ItemsSource = Enumerable.Range(startYear, currentYear - startYear + 1).Reverse();
        }


        private void LoadCarData(CarModel car)
        {
            BrandComboBox.SelectedItem = Enum.Parse(typeof(Brand), car.Brand);
            ModelTextBox.Text = car.Model;
            ProductionYearComboBox.SelectedItem = car.ProductionYear;
            LicensePlateTextBox.Text = car.LicensePlate;
            VINTextBox.Text = car.VIN;
            EngineTextBox.Text = car.Engine;
            FuelTypeComboBox.SelectedItem = (FuelType)car.FuelType;
            GearboxComboBox.SelectedItem = (Gearbox)car.Gearbox;
            VehicleClassComboBox.SelectedItem = Enum.Parse(typeof(VehicleClass), car.VehicleClass);
            ColorComboBox.SelectedItem = Enum.Parse(typeof(Color), car.Color);
            MileageTextBox.Text = car.Mileage.ToString();
            StatusComboBox.SelectedItem = (CarStatus)car.StatusCar;

            DailyPrice13TextBox.Text = car.DailyPrice_1_3.ToString("F2");
            DailyPrice48TextBox.Text = car.DailyPrice_4_8.ToString("F2");
            DailyPrice915TextBox.Text = car.DailyPrice_9_15.ToString("F2");
            DailyPrice1629TextBox.Text = car.DailyPrice_16_29.ToString("F2");
            DailyPrice30PlusTextBox.Text = car.DailyPrice_30plus.ToString("F2");
            WeekendPriceTextBox.Text = car.WeekendPrice.ToString("F2");
            DepositTextBox.Text = car.Deposit.ToString("F2");

            if (!string.IsNullOrEmpty(car.ImagePath) && File.Exists(car.ImagePath))
            {
                PreviewImage.Source = new BitmapImage(new Uri(car.ImagePath));
                PreviewImage.Visibility = Visibility.Visible;
                DropHintText.Visibility = Visibility.Collapsed;
                ImageInfoText.Visibility = Visibility.Visible;
            }
        }

        private void ImageDropZone_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    _imagePath = files[0];

                    try
                    {
                        var image = new BitmapImage(new Uri(_imagePath));
                        PreviewImage.Source = image;
                        PreviewImage.Visibility = Visibility.Visible;
                        DropHintText.Visibility = Visibility.Collapsed;
                        ImageInfoText.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie mo¿na wczytaæ obrazu: " + ex.Message);
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditedCar = new CarModel
                {
                    CarId = _carId,
                    Brand = BrandComboBox.SelectedItem.ToString(),
                    Model = ModelTextBox.Text,
                    ProductionYear = (int)ProductionYearComboBox.SelectedItem,
                    LicensePlate = LicensePlateTextBox.Text,
                    VIN = VINTextBox.Text,
                    Engine = EngineTextBox.Text,
                    FuelType = (int)(FuelType)FuelTypeComboBox.SelectedItem,
                    Gearbox = (int)(Gearbox)GearboxComboBox.SelectedItem,
                    VehicleClass = VehicleClassComboBox.SelectedItem.ToString(),
                    Color = ColorComboBox.SelectedItem.ToString(),
                    Mileage = int.Parse(MileageTextBox.Text),
                    StatusCar = (int)(CarStatus)StatusComboBox.SelectedItem,
                    DailyPrice_1_3 = float.Parse(DailyPrice13TextBox.Text),
                    DailyPrice_4_8 = float.Parse(DailyPrice48TextBox.Text),
                    DailyPrice_9_15 = float.Parse(DailyPrice915TextBox.Text),
                    DailyPrice_16_29 = float.Parse(DailyPrice1629TextBox.Text),
                    DailyPrice_30plus = float.Parse(DailyPrice30PlusTextBox.Text),
                    WeekendPrice = float.Parse(WeekendPriceTextBox.Text),
                    Deposit = float.Parse(DepositTextBox.Text),
                    ImagePath = _imagePath
                };
                var carRepository = new CarRepository();  // U¿ywa domyœlnej metody GetConnection z RepositoryBase
                carRepository.UpdateCar(EditedCar);  // Zapisz zaktualizowany samochód

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas zapisu: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
