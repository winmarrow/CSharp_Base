using System;

namespace L_2_5.Enities
{
    public class NewNewsEventArgs : EventArgs
    {
        public NewNewsEventArgs(News news)
        {
            News = news;
        }

        public News News { get; }
    }
}