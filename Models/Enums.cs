namespace Car_Rental.Models
{
    public enum Brand
    {
        AlfaRomeo,
        Audi,
        BMW,
        Chevrolet,
        Chrysler,
        Dodge,
        Fiat,
        Ford,
        Genesis,
        GMC,
        Honda,
        Hyundai,
        Infiniti,
        Jaguar,
        Jeep,
        Kia,
        LandRover,
        Lexus,
        Lincoln,
        Maserati,
        Mazda,
        Mercedes,
        Mini,
        Mitsubishi,
        Nissan,
        Pagani,
        Peugeot,
        Porsche,
        RAM,
        Renault,
        Saab,
        Subaru,
        Suzuki,
        Tesla,
        Toyota,
        Volkswagen,
        Volvo
    }

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
        Black,
        Blue,
        Brown,
        Gray,
        Green,
        Orange,
        Pink,
        Purple,
        Red,
        Silver,
        White,
        Yellow,
        Beige,
        Burgundy,
        Champagne,
        Charcoal,
        Coral,
        Cream,
        ElectricBlue,
        Gold,
        Indigo,
        Lavender,
        Lime,
        Mint,
        NavyBlue,
        Olive,
        Peach,
        Platinum,
        Rose,
        Sapphire,
        Teal,
        Turquoise,
        Violet,
        SkyBlue,
        Aqua,
        Emerald,
        Mahogany,
        Tan,
        Mustard,
        Onyx,
        Ruby
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
