using MeterReadingMobile.Provider;
using SQLite;

namespace MeterReadingMobile
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string filenamedb);
        bool DatabaseExists(string filenamedb);
    }
}
