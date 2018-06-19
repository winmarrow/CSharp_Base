using System;

namespace L_2_1.Enums
{
    [Flags]
    public enum Knowledge
    {
        Full = 0,
        Math = 1 << 0,
        Phythics = 1 << 1,
        Chemistry = 1 << 2,
        Language= 1 << 3,
        Literature= 1 << 4,
        PhysicalEducation= 1 << 5,
    }
}