using Car_Rental.Models;

public class DamageModel
{
    public int DamageId { get; set; } // Id uszkodzenia
    public int CarId { get; set; } // Id pojazdu
    public string Side { get; set; } // Strona pojazdu
    public double X { get; set; } // Współrzędna X
    public double Y { get; set; } // Współrzędna Y
    public DamageType Type { get; set; } // Typ uszkodzenia
    public string Note { get; set; } // Notatki
}
