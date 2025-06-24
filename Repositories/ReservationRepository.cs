using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Car_Rental.Repositories
{
    public class ReservationRepository : RepositoryBase
    {
        #region Add

        public void AddReservation(ReservationModel reservation)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = @"INSERT INTO Reservation (CarID, UserID, CustomerID, StartDate, EndDate, StatusReservation, TotalPrice)
                              VALUES (@CarID, @UserID, @CustomerID, @StartDate, @EndDate, @StatusReservation, @TotalPrice);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarID", reservation.CarId);
                    command.Parameters.AddWithValue("@UserID", reservation.UserId);
                    command.Parameters.AddWithValue("@CustomerID", reservation.CustomerId);
                    command.Parameters.AddWithValue("@StartDate", reservation.StartDate.ToString("yyyy-MM-dd HH:mm"));
                    command.Parameters.AddWithValue("@EndDate", reservation.EndDate.ToString("yyyy-MM-dd HH:mm"));
                    command.Parameters.AddWithValue("@StatusReservation", reservation.StatusReservation);
                    command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region GetAll

        public List<ReservationModel> GetAllReservations()
        {
            var reservations = new List<ReservationModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Reservation";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(new ReservationModel
                        {
                            ReservationId = Convert.ToInt32(reader["ReservationId"]),
                            CarId = Convert.ToInt32(reader["CarID"]),
                            UserId = Convert.ToInt32(reader["UserID"]),
                            CustomerId = Convert.ToInt32(reader["CustomerID"]),
                            StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                            EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                            StatusReservation = Convert.ToInt32(reader["StatusReservation"]),
                            TotalPrice = float.Parse(reader["TotalPrice"].ToString())
                        });
                    }
                }
            }

            return reservations;
        }

        #endregion

        #region GetActiveReservationByCarId

        public ReservationModel GetActiveReservationByCarId(int carId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = @"SELECT * FROM Reservation 
                              WHERE CarId = @carId AND StatusReservation = @status 
                              ORDER BY EndDate DESC LIMIT 1";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carId", carId);
                    command.Parameters.AddWithValue("@status", (int)ReservationStatus.Active);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ReservationModel
                            {
                                ReservationId = Convert.ToInt32(reader["ReservationId"]),
                                CarId = Convert.ToInt32(reader["CarId"]),
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                                EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                                TotalPrice = float.Parse(reader["TotalPrice"].ToString()),
                                StatusReservation = Convert.ToInt32(reader["StatusReservation"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        #endregion

        #region GetActiveReservationsByCarId (Extended)

        public List<ReservationModel> GetActiveReservationsByCarId(int carId)
        {
            var reservations = new List<ReservationModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var query = @"
            SELECT r.*, 
                   c.LicensePlate, 
                   c.Brand AS CarBrand,
                   c.Model AS CarModel,
                   c.ProductionYear AS CarYear,
                   cust.FirstName || ' ' || cust.LastName AS CustomerFullName,
                   cust.PESEL AS CustomerPESEL,
                   u.FirstName || ' ' || u.LastName AS UserName
            FROM Reservation r
            JOIN Car c ON r.CarID = c.CarID
            JOIN Customer cust ON r.CustomerID = cust.CustomerID
            JOIN User u ON r.UserID = u.UserID
            WHERE r.CarID = @CarID 
              AND (r.StatusReservation = @Status1 OR r.StatusReservation = @Status2)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarID", carId);
                    command.Parameters.AddWithValue("@Status1", (int)ReservationStatus.Planned);
                    command.Parameters.AddWithValue("@Status2", (int)ReservationStatus.Active);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new ReservationModel
                            {
                                ReservationId = Convert.ToInt32(reader["ReservationId"]),
                                CarId = Convert.ToInt32(reader["CarID"]),
                                UserId = Convert.ToInt32(reader["UserID"]),
                                CustomerId = Convert.ToInt32(reader["CustomerID"]),
                                StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                                EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                                StatusReservation = Convert.ToInt32(reader["StatusReservation"]),
                                TotalPrice = float.Parse(reader["TotalPrice"].ToString()),

                                LicensePlate = reader["LicensePlate"].ToString(),
                                CarBrand = reader["CarBrand"].ToString(),
                                CarModel = reader["CarModel"].ToString(),
                                CarYear = Convert.ToInt32(reader["CarYear"]),
                                CustomerFullName = reader["CustomerFullName"].ToString(),
                                CustomerPESEL = reader["CustomerPESEL"].ToString(),
                                UserName = reader["UserName"].ToString()
                            });
                        }
                    }
                }
            }

            return reservations;
        }

        #endregion

        #region Update (rozszerzona)

        public void UpdateReservation(ReservationModel reservation)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = @"
                UPDATE Reservation 
                SET 
                    CarID = @CarID,
                    UserID = @UserID,
                    CustomerID = @CustomerID,
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    StatusReservation = @StatusReservation,
                    TotalPrice = @TotalPrice
                WHERE ReservationId = @ReservationId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarID", reservation.CarId);
                    command.Parameters.AddWithValue("@UserID", reservation.UserId);
                    command.Parameters.AddWithValue("@CustomerID", reservation.CustomerId);
                    command.Parameters.AddWithValue("@StartDate", reservation.StartDate.ToString("yyyy-MM-dd HH:mm"));
                    command.Parameters.AddWithValue("@EndDate", reservation.EndDate.ToString("yyyy-MM-dd HH:mm"));
                    command.Parameters.AddWithValue("@StatusReservation", reservation.StatusReservation);
                    command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);
                    command.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Delete

        public void DeleteReservation(int reservationId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = @"DELETE FROM Reservation WHERE ReservationId = @ReservationId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReservationId", reservationId);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}