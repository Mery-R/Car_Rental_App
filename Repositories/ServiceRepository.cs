using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace Car_Rental.Repositories
{
    public class ServiceRepository : RepositoryBase
    {
        // Dodanie usługi
        public void AddService(ServiceModel service)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Service 
                                    (CarId, StartDate, EndDate, Description, StatusService)
                                    VALUES (@CarId, @StartDate, @EndDate, @Description, @StatusService)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CarId", service.CarId);
                        cmd.Parameters.AddWithValue("@StartDate", service.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", service.EndDate);
                        cmd.Parameters.AddWithValue("@Description", service.Description);
                        cmd.Parameters.AddWithValue("@StatusService", service.StatusService);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Obsługuje wyjątek
                Debug.WriteLine($"Error adding service: {ex.Message}");
                throw;
            }
        }

        // Pobranie wszystkich usług
        public List<ServiceModel> GetAllServices()
        {
            var services = new List<ServiceModel>();
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Service";
                    using (var cmd = new SQLiteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(ReadService(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching services: {ex.Message}");
                throw;
            }
            return services;
        }

        // Pobranie usług po CarId
        public List<ServiceModel> GetServicesByCarId(int carId)
        {
            var services = new List<ServiceModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Service WHERE CarId = @CarId";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(ReadService(reader));  // StatusService odczytany jako int
                        }
                    }
                }
            }
            return services;
        }


        // Usunięcie usługi
        public void DeleteService(int serviceId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Service WHERE ServiceId = @ServiceId";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ServiceId", serviceId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateService(ServiceModel service)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Service 
                         SET CarId = @CarId,
                             StartDate = @StartDate,
                             EndDate = @EndDate,
                             Description = @Description,
                             StatusService = @StatusService
                         WHERE ServiceId = @ServiceId";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CarId", service.CarId);
                    cmd.Parameters.AddWithValue("@StartDate", service.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", service.EndDate);
                    cmd.Parameters.AddWithValue("@Description", service.Description);
                    cmd.Parameters.AddWithValue("@StatusService", service.StatusService);  // Przekazywanie int
                    cmd.Parameters.AddWithValue("@ServiceId", service.ServiceId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Pomocnicza metoda do mapowania wiersza na obiekt ServiceModel
        private ServiceModel ReadService(SQLiteDataReader reader)
        {
            return new ServiceModel
            {
                ServiceId = reader.GetInt32(reader.GetOrdinal("ServiceId")),
                CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                StatusService = reader.GetInt32(reader.GetOrdinal("StatusService"))
            };
        }
    }
}
