using System;

namespace MeterReadingMobile.WebApi.Intrata.Model
{
    public class YearBase : ModelBase
    {
        public int instalacjaid { get; set; }
        public string kod { get; set; }

        public DateTime oddaty { get; set; }
        public DateTime dodaty { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static YearBase NewRecord(int instalacjaId)
        {
            YearBase ret = new YearBase()
            {
                instalacjaid = instalacjaId,
                id = -1
            };
            return ret;
        }
    }
}

