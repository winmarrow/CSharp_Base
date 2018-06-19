using L_2_1.Enums;

namespace L_2_1.Entities
{
    public class Lection
    {
        // TODO Сеттеры могут быть опущены или сделанными приватными
        public Knowledge Type { get; set; }
        public string Theme { get; set; }
        public int Classroom { get; set; }

        public Lection()
        {
        }

        public Lection(Knowledge type, string theme, int classroom)
        {
            Type = type;
            Theme = theme;
            Classroom = classroom;
        }
    }
}