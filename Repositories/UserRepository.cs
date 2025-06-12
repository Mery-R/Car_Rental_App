using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Car_Rental.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO User (Username, Password, Name, LastName, Email, Access) VALUES (@username, @password, @name, @lastName, @email, @access)";
                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@password", userModel.Password); 
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastName", userModel.LastName);
                command.Parameters.AddWithValue("@email", userModel.Email);
                command.Parameters.AddWithValue("@access", userModel.Access);
                command.ExecuteNonQuery();
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Username, Password FROM User WHERE Username = @username";
                command.Parameters.AddWithValue("@username", credential.UserName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedUsername = reader["Username"].ToString();
                        string storedPassword = reader["Password"].ToString();

                        // Haszujemy hasło wpisane przez użytkownika
                        string inputPassword = credential.Password;

                        // Porównujemy hasze
                        if (storedPassword == inputPassword)
                        {
                            validUser = true;
                        }
                        else
                        {
                            Console.WriteLine("Password does not match.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username not found.");
                    }
                }
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE User SET Username = @username, Name = @name, LastName = @lastName, Email = @email, Access = @access WHERE Id = @id";
                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastName", userModel.LastName);
                command.Parameters.AddWithValue("@email", userModel.Email);
                command.Parameters.AddWithValue("@access", userModel.Access);
                command.Parameters.AddWithValue("@id", userModel.Id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserModel> GetByAll()
        {
            List<UserModel> users = new List<UserModel>();
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM User";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        });
                    }
                }
            }
            return users;
        }

        public UserModel GetById(int id)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM User WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        };
                    }
                }
            }
            return user;
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM User WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        };
                    }
                }
            }
            return user;
        }

        public bool IsAccess(string username)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Access FROM User WHERE Username = @username";
                command.Parameters.AddWithValue("@username", username);

                object result = command.ExecuteScalar();
                return result != null && Convert.ToBoolean(result);
            }
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM User WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public UserRepository()
        {
            InitializeDatabase(); // Tworzenie bazy i tabeli przy inicjalizacji repozytorium
        }

        public void InitializeDatabase()
        {
            // Testowanie połączenia
            bool isDatabaseConnected = TestDatabaseConnection();
            if (isDatabaseConnected)
            {
                Console.WriteLine("Połączenie z bazą danych powiodło się.");
            }
            else
            {
                Console.WriteLine("Błąd połączenia z bazą danych.");
            }

            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");

            if (!File.Exists("Data/users.db"))
            {
                SQLiteConnection.CreateFile("Data/users.db");

                using (var connection = new SQLiteConnection("Data Source=Data/users.db;Version=3;"))
                {
                    connection.Open();

                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS User (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Name TEXT,
                        LastName TEXT,
                        Email TEXT,
                        Access BIT NOT NULL DEFAULT 0
                    );";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool TestDatabaseConnection()
        {
            try
            {
                using (var connection = TestConnection())
                {
                    connection.Open(); // Otwieramy połączenie

                    using (var command = new SQLiteCommand("SELECT 1", connection))
                    {
                        var result = command.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Błąd połączenia z bazą danych: {ex.Message}");
                return false;
            }
        }

    }
}
