using System;
using System.Collections.Generic;
using L_2_2.Collections;
using SharedLib.Abstract;
using SharedLib.ConsoleHelpers;

using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_2.Entities
{
    public class University
    {
        private readonly Logger _logger;

        public HomoSapiensCollection Students { get; }
        public HomoSapiensCollection Lecturers { get; }
        public HomoSapiensCollection HedLecturrers { get; }


        public University()
        {
            _logger = new ConsoleLogger();

            Students = new HomoSapiensCollection(_logger);
            Lecturers = new HomoSapiensCollection(_logger);
            HedLecturrers = new HomoSapiensCollection(_logger);
        }

        public void UniversityWork()
        {
            foreach (var student in Students)
                student.Work();

            CH.WriteSeparator();

            foreach (var lecturer in Lecturers)
                lecturer.Work();

            CH.WriteSeparator();

            foreach (var hedLecturrer in HedLecturrers)
                hedLecturrer.Work();

        }

    }
}