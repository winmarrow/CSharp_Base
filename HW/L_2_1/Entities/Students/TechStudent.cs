using L_2_1.Enums;

namespace L_2_1.Entities.Students
{
    public class TechStudent : Student
    {
        public TechStudent(string fullName)
            : base(fullName, Knowledge.Math | Knowledge.Phythics | Knowledge.Chemistry)
        {
        }
    }
}