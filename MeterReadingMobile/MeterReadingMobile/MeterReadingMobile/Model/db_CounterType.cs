using SQLite;

namespace MeterReadingMobile.Model
{
    public class db_CounterType : EntityBase
    {
        public db_CounterType() : base()
        {
        }

        public string code { get; set; }
        public string description { get; set; }

    }
}
