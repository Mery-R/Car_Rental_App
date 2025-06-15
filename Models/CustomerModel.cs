using System;

namespace Car_Rental.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PESEL { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
