using MeterReadingMobile.Model;

namespace MeterReadingMobile.Provider
{
    public partial class DBConnector
    {
        public void CreateTables()
        {
            _database.CreateTable<db_UnitOfMeasure>();
            _database.CreateTable<db_Location>();
            _database.CreateTable<db_CounterType>();
            _database.CreateTable<db_CounterSubType>();
            _database.CreateTable<db_Property>();
        }
    }
}
