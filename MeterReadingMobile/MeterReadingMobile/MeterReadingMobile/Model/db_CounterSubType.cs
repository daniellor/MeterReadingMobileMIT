using SQLite;

namespace MeterReadingMobile.Model
{
    public class db_CounterSubType : EntityBase
    {
        public db_CounterSubType() : base()
        {
        }

        public string code { get; set; }
        public string description { get; set; }

        [Indexed]
        public int countertypeid { get; set; }

    }
}
