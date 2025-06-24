using System;
using System.Data.SQLite;
using System.IO;

class DatabaseInitializer
{
    private static string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");
    private static string dbFile = Path.Combine(dataFolder, "data.db");

    // Metoda sprawdzająca, czy baza danych istnieje
    public static void InitializeDatabase()
    {
        // Upewnij się, że folder Data istnieje
        if (!Directory.Exists(dataFolder))
        {
            Directory.CreateDirectory(dataFolder);
        }

        // Sprawdzenie, czy plik bazy danych istnieje
        if (!File.Exists(dbFile))
        {
            // Jeśli baza nie istnieje, tworzona jest nowa baza danych
            SQLiteConnection.CreateFile(dbFile);
            Console.WriteLine("Baza danych została utworzona.");

            // Skrypt SQL do stworzenia tabel i dodania danych
            string createTableSql = @"
                -- Tworzenie tabeli User (pracownicy firmy)
                CREATE TABLE IF NOT EXISTS User (
                    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT,
                    Access INTEGER NOT NULL DEFAULT 0
                );

                -- Tworzenie tabeli Customer (klienci końcowi)
                CREATE TABLE IF NOT EXISTS Customer (
                    CustomerId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT,
                    Phone TEXT,
                    PESEL TEXT,
                    DriverLicenseNumber TEXT,
                    DateOfBirth TEXT,
                    Street TEXT,
                    City TEXT,
                    PostalCode TEXT
                );

                -- Tworzenie tabeli Car
                CREATE TABLE IF NOT EXISTS Car (
                    CarId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Brand TEXT NOT NULL,
                    Model TEXT NOT NULL,
                    ProductionYear INTEGER NOT NULL,
                    LicensePlate TEXT NOT NULL UNIQUE,
                    VIN TEXT UNIQUE,
                    Engine TEXT,
                    FuelType INTEGER,
                    Gearbox INTEGER,
                    VehicleClass TEXT,
                    Color TEXT,
                    Mileage INTEGER,
                    StatusCar INTEGER NOT NULL DEFAULT 0,
                    DailyPrice_1_3 REAL,
                    DailyPrice_4_8 REAL,
                    DailyPrice_9_15 REAL,
                    DailyPrice_16_29 REAL,
                    DailyPrice_30plus REAL,
                    WeekendPrice REAL,
                    Deposit REAL,
                    ImagePath TEXT
                );

                -- Tworzenie tabeli Reservation
                CREATE TABLE IF NOT EXISTS Reservation (
                    ReservationId INTEGER PRIMARY KEY AUTOINCREMENT,
                    CarID INTEGER NOT NULL,
                    UserID INTEGER NOT NULL,
                    CustomerID INTEGER,
                    StartDate TEXT NOT NULL,
                    EndDate TEXT NOT NULL,
                    StatusReservation INTEGER NOT NULL DEFAULT 0, -- 0 = zaplanowana, 1 = aktywna, 2 = zakończona, 3 = anulowana
                    TotalPrice REAL,
                    FOREIGN KEY (CarID) REFERENCES Car(CarID),
                    FOREIGN KEY (UserID) REFERENCES User(UserID),
                    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
                );

                -- Tworzenie tabeli Service
                CREATE TABLE IF NOT EXISTS Service (
                    ServiceId INTEGER PRIMARY KEY AUTOINCREMENT,
                    CarId INTEGER NOT NULL,
                    StartDate TEXT NOT NULL,
                    EndDate TEXT NOT NULL,
                    [Description] TEXT,
                    StatusService INTEGER NOT NULL DEFAULT 0,
                    FOREIGN KEY (CarId) REFERENCES Car(CarId)
                );

                CREATE TABLE IF NOT EXISTS Damage (
                DamageId INTEGER PRIMARY KEY AUTOINCREMENT,
                CarId INTEGER NOT NULL,
                ReservationId INTEGER,
                Side INTEGER NOT NULL,
                X REAL NOT NULL,
                Y REAL NOT NULL,
                Type TEXT NOT NULL,
                Note TEXT,
                FOREIGN KEY (CarId) REFERENCES Car(CarID),
                FOREIGN KEY (ReservationId) REFERENCES Reservation(ReservationId)
                );


                -- Dodanie domyślnego użytkownika admin
                INSERT OR IGNORE INTO User (Username, Password, FirstName, LastName, Email, Access)
                VALUES
                ('admin', 'admin', 'Miłosz', 'Stec', 'smilosz11@gmail.com', 1),
                ('user', 'user', 'Adam', 'Puc', 'apuc@student.agh.edu.pl', 0);

                -- Dodanie przykładowych klientów
                INSERT OR IGNORE INTO Customer (FirstName, LastName, Email, Phone, PESEL, DriverLicenseNumber, DateOfBirth, Street, City, PostalCode)
                VALUES
                ('Jan', 'Kowalski', 'jan.kowalski@example.com', '123456789', '12345678901', 'B1234567', '1985-07-10', 'ul. Warszawska 1', 'Warszawa', '00-001'),
                ('Anna', 'Nowak', 'anna.nowak@example.com', '987654321', '98765432109', 'A7654321', '1990-05-21', 'ul. Krakowska 10', 'Kraków', '30-100');

                -- Dodanie przykładowych aut
                INSERT OR IGNORE INTO Car (Brand, Model, ProductionYear, LicensePlate, VIN, Engine, FuelType, Gearbox, VehicleClass, Color, Mileage, StatusCar, DailyPrice_1_3, DailyPrice_4_8, DailyPrice_9_15, DailyPrice_16_29, DailyPrice_30plus, WeekendPrice, Deposit, ImagePath)
                VALUES
                ('Ford', 'Focus', 2019, 'XYZ789', '1FABP3AN9BM154121', '2.0L', 1, 0, 'C', 'Blue', 20000, 4, 55.0, 50.0, 45.0, 40.0, 35.0, 65.0, 500.0, '/images/ford_focus.jpg'),
                ('Volkswagen', 'Golf', 2018, 'DEF456', 'WVWZZZ1KZBW000001', '1.4L', 0, 1, 'C', 'White', 25000, 1, 52.0, 47.0, 43.0, 38.0, 34.0, 62.0, 500.0, '/images/vw_golf.jpg'),
                ('Honda', 'Civic', 2022, 'JKL012', '2HGFC2F69KH512345', '1.5L', 0, 1, 'C', 'Red', 5000, 0, 60.0, 55.0, 50.0, 45.0, 40.0, 70.0, 600.0, '/images/honda_civic.jpg');

            ";

            // Połączenie z bazą danych i wykonanie skryptu SQL
            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(createTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Tabela i dane zostały dodane.");
            }
        }
        else
        {
            Console.WriteLine("Baza danych już istnieje.");
        }
    }
}