using Car_Rental.Models;
using Car_Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

public class DamageRepository : RepositoryBase
{
    // Metoda dodająca nowe uszkodzenie do bazy
    public void AddDamage(DamageModel damage)
    {
        using (var connection = GetConnection())
        {
            try
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                INSERT INTO Damage (CarId, Side, X, Y, Type, Note, ReservationId)
                VALUES (@CarId, @Side, @X, @Y, @DamageType, @Note, @ReservationId);
                ";

                command.Parameters.AddWithValue("@CarId", damage.CarId);
                command.Parameters.AddWithValue("@Side", damage.Side);
                command.Parameters.AddWithValue("@X", damage.X);
                command.Parameters.AddWithValue("@Y", damage.Y);
                command.Parameters.AddWithValue("@DamageType", (int)damage.Type); // Zapisujemy typ uszkodzenia
                command.Parameters.AddWithValue("@Note", damage.Note);

                // Dodajemy sprawdzenie, czy ReservationId jest null
                command.Parameters.AddWithValue("@ReservationId", (object)damage.ReservationId ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }



    // Metoda pobierająca uszkodzenia z bazy na podstawie CarId
    public List<DamageModel> GetDamagesByCarId(int carId)
    {
        var damages = new List<DamageModel>();

        using (var connection = GetConnection())
        {
            try
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Damage WHERE CarId = @CarId;";
                command.Parameters.AddWithValue("@CarId", carId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var damage = new DamageModel
                        {
                            DamageId = reader.GetInt32(reader.GetOrdinal("DamageId")),
                            CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                            ReservationId = reader.IsDBNull(reader.GetOrdinal("ReservationId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReservationId")),
                            Side = reader.GetInt32(reader.GetOrdinal("Side")),
                            X = reader.GetDouble(reader.GetOrdinal("X")),
                            Y = reader.GetDouble(reader.GetOrdinal("Y")),
                            Type = (DamageType)Enum.Parse(typeof(DamageType), reader.GetString(reader.GetOrdinal("Type"))),
                            Note = reader.GetString(reader.GetOrdinal("Note"))
                        };
                        damages.Add(damage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        return damages;
    }
}
