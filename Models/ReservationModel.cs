using Car_Rental.Repositories;
using System;

namespace Car_Rental.Models
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }         // PRIMARY KEY
        public int CarId { get; set; }                 // FOREIGN KEY to Car
        public int UserId { get; set; }                // FOREIGN KEY to User (pracownik)
        public int CustomerId { get; set; }            // FOREIGN KEY to Customer (klient)
        public DateTime StartDate { get; set; }        // Start daty wypożyczenia
        public DateTime EndDate { get; set; }          // Koniec wypożyczenia
        public int StatusReservation { get; set; }     // 0=zaplanowana, 1=aktywna, 2=zakończona, 3=anulowana
        public float TotalPrice { get; set; }          // Koszt całkowity



        public string LicensePlate { get; set; }
        public string CustomerFullName { get; set; }   // Imię i nazwisko klienta
        public string CustomerPESEL { get; set; }   // Imię i nazwisko klienta
        public string UserName { get; set; }      // Imię i nazwisko pracownika
    }
}
