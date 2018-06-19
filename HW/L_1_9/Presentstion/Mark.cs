using System;

namespace L_1_9.Presentstion
{
    public struct Mark : IComparable
    {
        public DateTime Date;
        public string LectureName;
        public int MarkNumber;

        public int CompareTo(object obj)
        {
            Mark mark = (Mark) obj;
            return mark .MarkNumber - this.MarkNumber;
        }

        public static bool IsMarkValid(Mark mark)
        {
            return !string.IsNullOrWhiteSpace(mark.LectureName)
                   && mark.MarkNumber > 0 && mark.MarkNumber <= 10
                   && mark.Date != default(DateTime);
        }
    }
}
