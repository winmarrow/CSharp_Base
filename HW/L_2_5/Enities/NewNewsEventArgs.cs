using System;
using L_2_5.Enums;

namespace L_2_5.Enities
{
    public class NewNewsEventArgs : EventArgs
    {
        public NewsCategory Category;
        public int NewsIndex;

        public NewNewsEventArgs(NewsCategory category, int newsIndex)
        {
            Category = category;
            NewsIndex = newsIndex;
        }
    }
}