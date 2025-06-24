using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static int UserId { get; set; } // Można rozszerzyć o więcej danych
    }
}
