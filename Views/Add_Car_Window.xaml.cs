using Car_Rental.Models;
using Car_Rental.Repositories;
using Car_Rental.Views;
using System;
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


        public Add_Car_Window()
        {
            InitializeComponent();
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
                NewCar = new CarModel
                {
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