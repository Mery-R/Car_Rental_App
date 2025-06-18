namespace Car_Rental.Models
{
    public enum Brand { Toyota, Ford, BMW }
    public enum CarStatus
    {
        Available = 0,  // Dostępny
        Reserved = 1,   // Zarezerwowany
        Rented = 2,     // Wypożyczony
        ServicePlanned = 3, // W naprawie
        ServiceInProgress = 4 // W trakcie serwisu
    }
    public enum Color 
    { 
        Red, 
        Blue, 
        Green,
        Black,
        White,
        Yellow,
    }
    public enum FuelType 
    { 
        Petrol = 0, 
        Diesel = 1, 
        Electric = 2,
        Hybrid = 3
    }
    public enum Gearbox 
    { 
        Manual = 0, 
        Automatic = 1,
        CVT = 2
    }
    public enum VehicleClass 
    { 
        A, 
        B, 
        C,
        D,
        E,
        F,
        J,
        M,
        S
    }
    public enum ReservationStatus
    {
        Planned = 0,
        Active = 1,
        Finished = 2,
        Cancelled = 3
    }
    public enum ServiceStatus
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
