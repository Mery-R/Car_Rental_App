using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Car_Rental.Repositories
{
    public class ReservationRepository : RepositoryBase
    {
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
                    command.Parameters.AddWithValue("@StartDate", reservation.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", reservation.EndDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@StatusReservation", reservation.StatusReservation);
                    command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<ReservationModel> GetAllReservations()
        {
            var reservations = new List<ReservationModel>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var query = "SELECT * FROM Reservation";

                using (var command = new SQLiteCommand(query, connection))
                {
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
            }

            return reservations;
        }

        public ReservationModel GetActiveReservationByCarId(int carId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Reservation WHERE CarId = @carId AND StatusReservation = @status ORDER BY EndDate DESC LIMIT 1";
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


        public void UpdateReservation(ReservationModel reservation)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"UPDATE Reservation 
                      SET StatusReservation = @status 
                      WHERE ReservationId = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", reservation.StatusReservation);
                    command.Parameters.AddWithValue("@id", reservation.ReservationId);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
