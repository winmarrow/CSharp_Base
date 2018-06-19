using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_2_1.Entities;
using L_2_1.Entities.Students;
using L_2_1.Enums;

namespace L_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            var univercity = new Univercity();

            univercity.Humans.AddRange(new List<Human>()
            {
                new TechStudent("TechStudent 1"), //0
                new TechStudent("TechStudent 2"), 
                new TechStudent("TechStudent 3"), 
                new TechStudent("TechStudent 4"), 
                new TechStudent("TechStudent 5"), 

                new HumanistStudent("HumanistStudent 1"), //5
                new HumanistStudent("HumanistStudent 2"),
                new HumanistStudent("HumanistStudent 3"),
                new HumanistStudent("HumanistStudent 4"),
                new HumanistStudent("HumanistStudent 5"),

                new Student("Stupid student", Knowledge.Full), //10
                new Student("Bastard student", Knowledge.Full),

                new Lecturrer("Lecturer with glasses 1", Knowledge.Math | Knowledge.Phythics | Knowledge.Chemistry), //12
                new Lecturrer("Tiny Lecturer 2", Knowledge.Language | Knowledge.Literature),
                new Lecturrer("Strong Lecturer 3", Knowledge.PhysicalEducation),
                new Lecturrer("Old Lecturer 4", Knowledge.Full),

                new Human("Some human 1"), //16
                new Human("Some human 1"),

                new AthleteStudent("Lost AthleteStudent")
            });


            univercity.Lections.Add(new Lection(Knowledge.Math, "Calculations in colum", 21),new List<Human>()
            {
                univercity.Humans[0],
                univercity.Humans[2],
                univercity.Humans[3],
                univercity.Humans[5],
                univercity.Humans[6],
                univercity.Humans[11],

                univercity.Humans[12],

                univercity.Humans[16],
            } );

            univercity.Lections.Add(new Lection(Knowledge.Math, "Integrals",06), new List<Human>()
            {
                univercity.Humans[1],
                univercity.Humans[5],
                univercity.Humans[6],
                univercity.Humans[7],
                univercity.Humans[8],
                univercity.Humans[10],
                univercity.Humans[11],

                univercity.Humans[12],
            });

            univercity.Lections.Add(new Lection(Knowledge.Literature, "\"Puskin\" as greatest Russina writer", 206), new List<Human>()
            {
                univercity.Humans[1],
                univercity.Humans[5],
                univercity.Humans[6],
                univercity.Humans[3],
                univercity.Humans[7],
                univercity.Humans[8],
                univercity.Humans[10],

                univercity.Humans[12],
                univercity.Humans[15],
            });

            univercity.Lections.Add(new Lection(Knowledge.PhysicalEducation, "Who can run to death", 0), new List<Human>()
            {
                univercity.Humans[1],
                univercity.Humans[5],
                univercity.Humans[6],
                univercity.Humans[3],
                univercity.Humans[7],
                univercity.Humans[8],
                univercity.Humans[10],

                univercity.Humans[15],

                univercity.Humans[16],
                univercity.Humans[17],

                univercity.Humans[18],
            });


            univercity.CheckLections();

            Console.ReadKey();
        }
    }
}
