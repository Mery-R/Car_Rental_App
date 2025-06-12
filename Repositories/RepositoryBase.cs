using System.Data;
using System.Data.SQLite;
namespace Car_Rental.Repositories

{
    public class RepositoryBase
    {
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=Data/users.db;Version=3;");
        }

        public SQLiteConnection TestConnection()
        {
            return new SQLiteConnection("Data Source=Data/users.db;Version=3;");
        }

    }
}
