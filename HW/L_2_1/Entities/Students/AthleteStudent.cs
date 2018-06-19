using System;
using L_2_1.Enums;

namespace L_2_1.Entities.Students
{
    public class AthleteStudent
        : Student
    {
        public AthleteStudent(string fullName)
            : base(fullName, Knowledge.PhysicalEducation)
        {

        }

        public override void Learn(Knowledge lectureType)
        {
            base.Learn(lectureType);
            Console.WriteLine("The only student who running");
        }
    }
}