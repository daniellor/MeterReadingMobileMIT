using System;

namespace MeterReadingMobile
{
    [Flags]
    public enum CrudFlags
    {
        Delete = 0x0,
        Edit = 0x1,
        Add = 0x2,
        Unspecified = 0x3
    }
}
