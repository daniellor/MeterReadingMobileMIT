using SQLite;

namespace MeterReadingMobile.Model
{
    public class db_UnitOfMeasure : EntityBase
    {
        public db_UnitOfMeasure() : base()
        {
        }

        public string code { get; set; }
        public string description { get; set; }

    }
}
