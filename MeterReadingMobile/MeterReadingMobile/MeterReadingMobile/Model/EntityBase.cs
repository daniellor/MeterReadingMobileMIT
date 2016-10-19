using SQLite;
using System;

namespace MeterReadingMobile.Model
{
    public class EntityBase : IEntityBase
    {

        public EntityBase()
        {
            guid = Guid.NewGuid();
        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public Guid guid { get; set; }
        public int rowversion { get; set; }

    }
}
