using System;

namespace TDS
{
    public enum SideType : byte
    {
        None = 0,
        Friendly = 1,
        Enemy = 2,
    }

    public enum ProjectileType : byte
    {
        None = 0,
        Тear = 1,
        Further = 2,
    }

    [Flags]
    public enum IgnoreAxisType : byte
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4,
    }

    public enum AISttateType : byte
    {
        None = 0,
        Wait = 1, 
        Move_Seek = 230,
        Move_Flee = 231,// мб не понадобится
        Move_Arrival = 232,
        Move_Wander = 233,
        Move_Pursuing = 234,// мб не понадобится
        Move_Evading = 235,// мб не понадобится
    }
}
