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
                INSERT INTO Damage (CarId, Side, X, Y, Type, Note)
                VALUES (@CarId, @Side, @X, @Y, @DamageType, @Note);
            ";

                command.Parameters.AddWithValue("@CarId", damage.CarId);
                command.Parameters.AddWithValue("@Side", damage.Side);
                command.Parameters.AddWithValue("@X", damage.X);
                command.Parameters.AddWithValue("@Y", damage.Y);
                command.Parameters.AddWithValue("@DamageType", (int)damage.Type); // Zapisz jako numer typu
                command.Parameters.AddWithValue("@Note", damage.Note);

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
                            DamageId = reader.GetInt32(0),
                            CarId = reader.GetInt32(1),
                            Side = reader.GetString(2),
                            X = reader.GetDouble(3),
                            Y = reader.GetDouble(4),
                            Type = (DamageType)reader.GetInt32(5), // Odczytujemy typ jako DamageType enum
                            Note = reader.GetString(6)
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


    // Metoda, która wczytuje uszkodzenia i dodaje markery na canvasie
    public void LoadCarDamages(Canvas canvas, int carId)
    {
        var damages = GetDamagesByCarId(carId);

        foreach (var damage in damages)
        {
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

}
