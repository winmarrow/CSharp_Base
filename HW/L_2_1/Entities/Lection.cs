using L_2_1.Enums;

namespace L_2_1.Entities
{
    public class Lection
    {
        public Lection()
        {
        }

        public Lection(Knowledge type, string theme, int classroom)
        {
            Type = type;
            Theme = theme;
            Classroom = classroom;
        }

        public Knowledge Type { get; }
        public string Theme { get; }
        public int Classroom { get; }
    }
}