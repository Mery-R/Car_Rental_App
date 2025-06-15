using System.Data;
using System.Data.SQLite;
using System.IO;
namespace Car_Rental.Repositories

{
    public class RepositoryBase
    {
        // Metoda dostępna w klasach dziedziczących
        public SQLiteConnection GetConnection()
        {
            // Tworzenie ścieżki bezwzględnej do pliku bazy danych
            string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string dbFile = Path.Combine(dataFolder, "data.db");
            string connectionString = $"Data Source={dbFile};Version=3;";
            return new SQLiteConnection(connectionString);
        }

        // Metoda pomocnicza do testowania połączenia z bazą
        public SQLiteConnection TestConnection()
        {
            return GetConnection();
        }
    }
}
