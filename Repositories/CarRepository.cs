using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Car_Rental.Repositories
{
    public class CarRepository : RepositoryBase
    {
        public CarModel GetCarById(int carId)
        {
            // Deklaracja zmiennej connection


            using (var connection = GetConnection())
            {
                connection.Open();

                var query = "SELECT * FROM Car WHERE CarId = @CarId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CarModel
                            {
                                CarId = Convert.ToInt32(reader["CarId"]),
                                Brand = reader["Brand"].ToString(),
                                Model = reader["Model"].ToString(),
                                ProductionYear = Convert.ToInt32(reader["ProductionYear"]),
                                LicensePlate = reader["LicensePlate"].ToString(),
                                VIN = reader["VIN"]?.ToString(),
                                Engine = reader["Engine"]?.ToString(),
                                FuelType = Convert.ToInt32(reader["FuelType"]),
                                Gearbox = Convert.ToInt32(reader["Gearbox"]),
                                VehicleClass = reader["VehicleClass"]?.ToString(),
                                Color = reader["Color"]?.ToString(),
                                Mileage = Convert.ToInt32(reader["Mileage"]),
                                StatusCar = Convert.ToInt32(reader["StatusCar"]),
                                DailyPrice_1_3 = Convert.ToSingle(reader["DailyPrice_1_3"]),
                                DailyPrice_4_8 = Convert.ToSingle(reader["DailyPrice_4_8"]),
                                DailyPrice_9_15 = Convert.ToSingle(reader["DailyPrice_9_15"]),
                                DailyPrice_16_29 = Convert.ToSingle(reader["DailyPrice_16_29"]),
                                DailyPrice_30plus = Convert.ToSingle(reader["DailyPrice_30plus"]),
                                WeekendPrice = Convert.ToSingle(reader["WeekendPrice"]),
                                Deposit = Convert.ToSingle(reader["Deposit"]),
                                ImagePath = reader["ImagePath"]?.ToString()

                            };
                        }
                    }
                }
            }

            return null; // Zwraca null, jeśli samochód o takim ID nie istnieje
        }

        public List<CarModel> GetAllCars()
        {
            var cars = new List<CarModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Car";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var car = new CarModel
                        {
                            CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                            Brand = reader.GetString(reader.GetOrdinal("Brand")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            ProductionYear = reader.GetInt32(reader.GetOrdinal("ProductionYear")),
                            LicensePlate = reader.GetString(reader.GetOrdinal("LicensePlate")),
                            VIN = reader["VIN"] as string,
                            Engine = reader["Engine"] as string,
                            FuelType = reader.GetInt32(reader.GetOrdinal("FuelType")),
                            Gearbox = reader.GetInt32(reader.GetOrdinal("Gearbox")),
                            VehicleClass = reader["VehicleClass"] as string,
                            Color = reader["Color"] as string,
                            Mileage = reader.GetInt32(reader.GetOrdinal("Mileage")),
                            StatusCar = reader.GetInt32(reader.GetOrdinal("StatusCar")),
                            DailyPrice_1_3 = reader.GetFloat(reader.GetOrdinal("DailyPrice_1_3")),
                            DailyPrice_4_8 = reader.GetFloat(reader.GetOrdinal("DailyPrice_4_8")),
                            DailyPrice_9_15 = reader.GetFloat(reader.GetOrdinal("DailyPrice_9_15")),
                            DailyPrice_16_29 = reader.GetFloat(reader.GetOrdinal("DailyPrice_16_29")),
                            DailyPrice_30plus = reader.GetFloat(reader.GetOrdinal("DailyPrice_30plus")),
                            WeekendPrice = reader.GetFloat(reader.GetOrdinal("WeekendPrice")),
                            Deposit = reader.GetFloat(reader.GetOrdinal("Deposit")),
                            ImagePath = reader["ImagePath"] as string
                        };

                        cars.Add(car);
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"CarId: {car.CarId}, StatusCar: {car.StatusCar}");
            }
            return cars;
            

        }

        public List<CarModel> GetCarsByFilter(List<int> statusList, string searchText = null)
        {
            var cars = new List<CarModel>();
            using (var connection = GetConnection())
            {
                connection.Open();

                // Budujemy zapytanie dynamicznie, bo statusów może być wiele
                string query = "SELECT * FROM Car WHERE StatusCar IN (" +
                               string.Join(",", statusList) + ")";

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += " AND (" +
                             "LOWER(Brand) LIKE @search OR " +
                             "LOWER(Model) LIKE @search OR " +
                             "LOWER(LicensePlate) LIKE @search OR " +
                             "LOWER(Color) LIKE @search)";
                }

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        command.Parameters.AddWithValue("@search", "%" + searchText.ToLower() + "%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var car = new CarModel
                            {
                                CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                                Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                ProductionYear = reader.GetInt32(reader.GetOrdinal("ProductionYear")),
                                LicensePlate = reader.GetString(reader.GetOrdinal("LicensePlate")),
                                VIN = reader["VIN"] as string,
                                Engine = reader["Engine"] as string,
                                FuelType = reader.GetInt32(reader.GetOrdinal("FuelType")),
                                Gearbox = reader.GetInt32(reader.GetOrdinal("Gearbox")),
                                VehicleClass = reader["VehicleClass"] as string,
                                Color = reader["Color"] as string,
                                Mileage = reader.GetInt32(reader.GetOrdinal("Mileage")),
                                StatusCar = reader.GetInt32(reader.GetOrdinal("StatusCar")),
                                DailyPrice_1_3 = reader.GetFloat(reader.GetOrdinal("DailyPrice_1_3")),
                                DailyPrice_4_8 = reader.GetFloat(reader.GetOrdinal("DailyPrice_4_8")),
                                DailyPrice_9_15 = reader.GetFloat(reader.GetOrdinal("DailyPrice_9_15")),
                                DailyPrice_16_29 = reader.GetFloat(reader.GetOrdinal("DailyPrice_16_29")),
                                DailyPrice_30plus = reader.GetFloat(reader.GetOrdinal("DailyPrice_30plus")),
                                WeekendPrice = reader.GetFloat(reader.GetOrdinal("WeekendPrice")),
                                Deposit = reader.GetFloat(reader.GetOrdinal("Deposit")),
                                ImagePath = reader["ImagePath"] as string
                            };

                            cars.Add(car);
                        }
                    }
                }
            }
            return cars;
        }


        public void AddCar(CarModel car)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                    INSERT INTO Car 
                    (Brand, Model, ProductionYear, LicensePlate, VIN, Engine, FuelType, Gearbox, VehicleClass, Color, Mileage, StatusCar,
                     DailyPrice_1_3, DailyPrice_4_8, DailyPrice_9_15, DailyPrice_16_29, DailyPrice_30plus, WeekendPrice, Deposit, ImagePath)
                    VALUES 
                    (@Brand, @Model, @ProductionYear, @LicensePlate, @VIN, @Engine, @FuelType, @Gearbox, @VehicleClass, @Color, @Mileage, @StatusCar,
                     @DailyPrice_1_3, @DailyPrice_4_8, @DailyPrice_9_15, @DailyPrice_16_29, @DailyPrice_30plus, @WeekendPrice, @Deposit, @ImagePath)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@ProductionYear", car.ProductionYear);
                    command.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);
                    command.Parameters.AddWithValue("@VIN", car.VIN);
                    command.Parameters.AddWithValue("@Engine", car.Engine);
                    command.Parameters.AddWithValue("@FuelType", car.FuelType);
                    command.Parameters.AddWithValue("@Gearbox", car.Gearbox);
                    command.Parameters.AddWithValue("@VehicleClass", car.VehicleClass);
                    command.Parameters.AddWithValue("@Color", car.Color);
                    command.Parameters.AddWithValue("@Mileage", car.Mileage);
                    command.Parameters.AddWithValue("@StatusCar", car.StatusCar);
                    command.Parameters.AddWithValue("@DailyPrice_1_3", car.DailyPrice_1_3);
                    command.Parameters.AddWithValue("@DailyPrice_4_8", car.DailyPrice_4_8);
                    command.Parameters.AddWithValue("@DailyPrice_9_15", car.DailyPrice_9_15);
                    command.Parameters.AddWithValue("@DailyPrice_16_29", car.DailyPrice_16_29);
                    command.Parameters.AddWithValue("@DailyPrice_30plus", car.DailyPrice_30plus);
                    command.Parameters.AddWithValue("@WeekendPrice", car.WeekendPrice);
                    command.Parameters.AddWithValue("@Deposit", car.Deposit);
                    command.Parameters.AddWithValue("@ImagePath", car.ImagePath);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCar(CarModel car)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                    UPDATE Car SET 
                        Brand = @Brand,
                        Model = @Model,
                        ProductionYear = @ProductionYear,
                        LicensePlate = @LicensePlate,
                        VIN = @VIN,
                        Engine = @Engine,
                        FuelType = @FuelType,
                        Gearbox = @Gearbox,
                        VehicleClass = @VehicleClass,
                        Color = @Color,
                        Mileage = @Mileage,
                        StatusCar = @StatusCar,
                        DailyPrice_1_3 = @DailyPrice_1_3,
                        DailyPrice_4_8 = @DailyPrice_4_8,
                        DailyPrice_9_15 = @DailyPrice_9_15,
                        DailyPrice_16_29 = @DailyPrice_16_29,
                        DailyPrice_30plus = @DailyPrice_30plus,
                        WeekendPrice = @WeekendPrice,
                        Deposit = @Deposit,
                        ImagePath = @ImagePath
                    WHERE CarId = @CarId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", car.CarId);
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@ProductionYear", car.ProductionYear);
                    command.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);
                    command.Parameters.AddWithValue("@VIN", car.VIN);
                    command.Parameters.AddWithValue("@Engine", car.Engine);
                    command.Parameters.AddWithValue("@FuelType", car.FuelType);
                    command.Parameters.AddWithValue("@Gearbox", car.Gearbox);
                    command.Parameters.AddWithValue("@VehicleClass", car.VehicleClass);
                    command.Parameters.AddWithValue("@Color", car.Color);
                    command.Parameters.AddWithValue("@Mileage", car.Mileage);
                    command.Parameters.AddWithValue("@StatusCar", car.StatusCar);
                    command.Parameters.AddWithValue("@DailyPrice_1_3", car.DailyPrice_1_3);
                    command.Parameters.AddWithValue("@DailyPrice_4_8", car.DailyPrice_4_8);
                    command.Parameters.AddWithValue("@DailyPrice_9_15", car.DailyPrice_9_15);
                    command.Parameters.AddWithValue("@DailyPrice_16_29", car.DailyPrice_16_29);
                    command.Parameters.AddWithValue("@DailyPrice_30plus", car.DailyPrice_30plus);
                    command.Parameters.AddWithValue("@WeekendPrice", car.WeekendPrice);
                    command.Parameters.AddWithValue("@Deposit", car.Deposit);
                    command.Parameters.AddWithValue("@ImagePath", car.ImagePath);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCar(int carId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Car WHERE CarId = @CarId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
