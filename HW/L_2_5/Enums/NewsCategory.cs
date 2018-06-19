using System;

namespace L_2_5.Enums
{
    [Flags]
    public enum NewsCategory
    {
        News = 1,
        Weather = 1 << 2,
        Sport = 1 << 3,
        Events = 1 << 4,
        Humor = 1 << 5
    }
}