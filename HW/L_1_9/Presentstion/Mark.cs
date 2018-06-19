using System;

namespace L_1_9.Presentstion
{
    public struct Mark : IComparable
    {
        // TODO use auto properties
        public DateTime Date;
        public string LectureName;
        public int MarkNumber;

        public int CompareTo(object obj)
        {
            // TODO Не безопасно. Можете получить Invalid Cast Exception
            //Mark mark = (Mark) obj;
            //return mark.MarkNumber - this.MarkNumber;
            // TODO либо перенести тернарник внутрь CompareTo
            return obj is Mark mark 
                ? this.MarkNumber.CompareTo(mark.MarkNumber) 
                : this.MarkNumber.CompareTo(null);
        }

        public static bool IsMarkValid(Mark mark)
        {
            return !string.IsNullOrWhiteSpace(mark.LectureName)
                   && mark.MarkNumber > 0 && mark.MarkNumber <= 10
                   && mark.Date != default(DateTime);
        }
    }
}
