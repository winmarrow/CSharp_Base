using System.ComponentModel;

namespace L_2_6.Entities
{
    public class StudentCollectinChangedEventArgs : CollectionChangeEventArgs
    {
        public StudentCollectinChangedEventArgs(CollectionChangeAction action, object element, Student item) : base(
            action, element)
        {
            Student = item;
        }

        public Student Student { get; }
    }
}