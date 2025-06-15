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
                    Access INTEGER NOT NULL DEFAULT 0 -- 1 = admin, 0 = zwykły pracownik
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
                    FuelType INTEGER, -- 0 = benzyna, 1 = diesel, 2 = hybryda, 3 = elektryk
                    Gearbox INTEGER,  -- 0 = manual, 1 = automat
                    VehicleClass TEXT,-- np. B, C, D
                    Color TEXT,
                    Mileage INTEGER,
                    StatusCar INTEGER NOT NULL DEFAULT 0, -- 0 = dostępny, 1 = zarezerwowany, 2 = wypożyczony, 3 = serwis
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
                    FOREIGN KEY (CarId) REFERENCES Car(CarId)
                );

                CREATE TABLE IF NOT EXISTS Damage (
                DamageId INTEGER PRIMARY KEY AUTOINCREMENT,
                CarId INTEGER NOT NULL,
                ReservationId INTEGER,
                Side TEXT NOT NULL,
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
                ('Toyota', 'Corolla', 2020, 'ABC123', '1HGBH41JXMN109186', '1.8L', 0, 1, 'C', 'Biały', 15000, 0, 50.0, 45.0, 40.0, 35.0, 30.0, 60.0, 500.0, '/images/toyota_corolla.jpg'),
                ('Ford', 'Focus', 2019, 'XYZ789', '1FABP3AN9BM154121', '2.0L', 1, 0, 'C', 'Czerwony', 20000, 0, 55.0, 50.0, 45.0, 40.0, 35.0, 65.0, 500.0, '/images/ford_focus.jpg');

                -- Dodanie przykładowej rezerwacji
                INSERT OR IGNORE INTO Reservation (CarID, UserID, CustomerID, StartDate, EndDate, StatusReservation, TotalPrice)
                VALUES
                (1, 1, 1, '2025-06-15', '2025-06-20', 0, 250.0),  -- rezerwacja dla Toyoty przez Jana Kowalskiego
                (2, 2, 2, '2025-06-18', '2025-06-25', 0, 275.0);  -- rezerwacja dla Forda przez Annę Nowak

                -- Dodanie przykładowego serwisu
                INSERT OR IGNORE INTO Service (CarId, StartDate, EndDate, Description)
                VALUES
                (1, '2025-06-01', '2025-06-05', 'Przegląd techniczny'),
                (2, '2025-06-10', '2025-06-12', 'Wymiana oleju');
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