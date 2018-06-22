using System;

namespace L_1_9.Presentstion
{
    public struct Mark : IComparable
    {
        public DateTime Date { get; }
        public string LectureName { get; }
        public int MarkNumber { get; }

        public int CompareTo(object obj)
        {
            return obj is Mark mark
                ? MarkNumber.CompareTo(mark.MarkNumber)
                : MarkNumber.CompareTo(null);
        }

        public override bool Equals(object obj)
        {
            return obj is Mark mark
                   && MarkNumber == mark.MarkNumber
                   && LectureName == mark.LectureName
                   && Date == mark.Date;
        }

        public static bool IsMarkValid(Mark mark)
        {
            return !string.IsNullOrWhiteSpace(mark.LectureName)
                   && mark.MarkNumber > 0 && mark.MarkNumber <= 10
                   && mark.Date != default(DateTime);
        }
    }
}