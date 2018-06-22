using L_2_1.Enums;

namespace L_2_1.Entities.Students
{
    public class HumanistStudent : Student
    {
        public HumanistStudent(string fullName)
            : base(fullName, Knowledge.Language | Knowledge.Literature)
        {
        }
    }
}