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
    /// <summary>
    /// Klasa UserRepository implementuje operacje na użytkownikach w bazie danych.
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Dodaje nowego użytkownika do bazy danych.
        /// </summary>
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO User (Username, Password, FirstName, LastName, Email, Access) VALUES (@username, @password, @name, @lastName, @email, @access)";
                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@password", userModel.Password); 
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastName", userModel.LastName);
                command.Parameters.AddWithValue("@email", userModel.Email);
                command.Parameters.AddWithValue("@access", userModel.Access);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Sprawdza poprawność danych logowania użytkownika.
        /// </summary>
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

        /// <summary>
        /// Aktualizuje dane użytkownika w bazie.
        /// </summary>
        public void Edit(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE User SET Username = @username, FirstName = @name, LastName = @lastName, Email = @email, Access = @access WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastName", userModel.LastName);
                command.Parameters.AddWithValue("@email", userModel.Email);
                command.Parameters.AddWithValue("@access", userModel.Access);
                command.Parameters.AddWithValue("@UserId", userModel.UserId);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Pobiera wszystkich użytkowników z bazy.
        /// </summary>
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
                            UserId = reader["UserId"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        });
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Pobiera użytkownika po ID.
        /// </summary>
        public UserModel GetById(int UserId)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM User WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", UserId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            UserId = reader["UserId"]?.ToString(),

                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        };
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Pobiera użytkownika po nazwie użytkownika.
        /// </summary>
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
                            UserId = reader["UserId"]?.ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Hasło nie jest wyświetlane
                            Name = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Access = Convert.ToBoolean(reader["Access"]),
                        };
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Sprawdza, czy użytkownik ma uprawnienia administracyjne.
        /// </summary>
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

        /// <summary>
        /// Usuwa użytkownika z bazy po ID.
        /// </summary>
        public void Remove(int UserId)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM User WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", UserId);
                command.ExecuteNonQuery();
            }
        }

    }
}
