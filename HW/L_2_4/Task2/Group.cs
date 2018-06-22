using System.Collections.Generic;
using System.Linq;

namespace L_2_4.Task2
{
    public delegate int StudentSortDelegate(Student student1, Student student2);

    public delegate bool StudentSelectorDelegate(Student student);

    public delegate void StudentActionDelegate(Student student);

    public class Group
    {
        private readonly List<Student> _students;

        public Group()
        {
            _students = new List<Student>();
        }

        public Group(IEnumerable<Student> students)
        {
            _students = new List<Student>(students);
        }

        public void Sort(StudentSortDelegate studentSortDelegate)
        {
            _students.Sort((student1, student2) => studentSortDelegate(student1, student2));
        }

        public void DoSomethingWith(StudentSelectorDelegate studentSelector, StudentActionDelegate studentAction)
        {
            foreach (var student in _students.Where(student => studentSelector(student)))
                studentAction(student);
        }
    }
}