using Car_Rental.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Car_Rental.Repositories
{
    public class CustomerRepository : RepositoryBase
    {
        public List<CustomerModel> GetAllCustomers()
        {
            var customers = new List<CustomerModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Customer";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new CustomerModel
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            PESEL = reader["PESEL"].ToString(),
                            DriverLicenseNumber = reader["DriverLicenseNumber"].ToString(),
                            DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                            Street = reader["Street"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString()
                        });
                    }
                }
            }

            return customers;
        }
        public int AddCustomer(CustomerModel customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"INSERT INTO Customer 
                      (FirstName, LastName, Email, Phone, PESEL, DriverLicenseNumber, DateOfBirth, Street, City, PostalCode) 
                      VALUES 
                      (@FirstName, @LastName, @Email, @Phone, @PESEL, @DriverLicenseNumber, @DateOfBirth, @Street, @City, @PostalCode);
                      SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@PESEL", customer.PESEL);
                    command.Parameters.AddWithValue("@DriverLicenseNumber", customer.DriverLicenseNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@Street", customer.Street);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public CustomerModel GetCustomerById(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerModel
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                PESEL = reader["PESEL"].ToString(),
                                DriverLicenseNumber = reader["DriverLicenseNumber"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                Street = reader["Street"].ToString(),
                                City = reader["City"].ToString(),
                                PostalCode = reader["PostalCode"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

    }

}
