namespace Car_Rental.Models
{
    public class UserModel
    {
        public string UserId { get; set; }       // Możesz rozważyć typ GUID, jeśli Id jest unikalnym identyfikatorem
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Access { get; set; }      // Zmiana z string na bool
    }
}
