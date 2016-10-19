using System;

namespace MeterReadingMobile.WebApi.Intrata.Model
{
    public class ModelBase
    {
        public ModelBase() { }


        public int id { get; set; }
        public bool isselected { get; set; }


        public Guid guid { get; set; }
        public int rowversion { get; set; }

        public bool newrecord { get { return id == -1; } }

    }
}
