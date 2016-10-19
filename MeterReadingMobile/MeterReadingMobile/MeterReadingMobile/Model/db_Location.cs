using SQLite;

namespace MeterReadingMobile.Model
{
    public class db_Location : EntityBase
    {
        public db_Location() : base()
        {
        }

        public string code { get; set; }
        public string description { get; set; }

    }
}
