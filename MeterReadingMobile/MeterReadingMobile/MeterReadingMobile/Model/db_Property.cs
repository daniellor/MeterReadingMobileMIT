using SQLite;

namespace MeterReadingMobile.Model
{
    public class db_Property : EntityBase
    {
        public db_Property() : base()
        {
        }

        public string code { get; set; }
        public string shortname { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
        public string street { get; set; }
        public string housenumber { get; set; }
        public string apartmentnumber { get; set; }

    }
}
