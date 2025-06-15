namespace Car_Rental.Models
{
    public enum Brand { Toyota, Ford, BMW }
    public enum CarStatus
    {
        Available = 0,  // Dostępny
        Reserved = 1,   // Zarezerwowany
        Rented = 2,     // Wypożyczony
        Maintenance = 3 // W naprawie
    }
    public enum Color { Red, Blue, Green }
    public enum FuelType { Petrol, Diesel, Electric }
    public enum Gearbox { Manual, Automatic }
    public enum VehicleClass { Economy, Compact, SUV }

    public enum ReservationStatus
    {
        Planned = 0,
        Active = 1,
        Finished = 2,
        Cancelled = 3
    }
    public enum DamageType
    {
        Scratch = 1,
        Dent = 2,
        Chip = 3,
        Crack = 4,
        Other = 5
    }


}
