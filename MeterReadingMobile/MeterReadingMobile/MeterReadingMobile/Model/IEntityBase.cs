using System;

namespace MeterReadingMobile.Model
{
    public interface IEntityBase
    {
        Guid guid { get; set; }
        int id { get; set; }
        int rowversion { get; set; }
    }
}