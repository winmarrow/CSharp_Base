﻿using System;
using System.Collections.Generic;
using L_2_1.Enums;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_1.Entities
{
    public class Univercity
    {
        public List<Human> Humans { get; }
        public Dictionary<Lection,List<Human>> Lections { get;}

        public Univercity()
        {
            Humans = new List<Human>();
            Lections = new Dictionary<Lection, List<Human>>();
        }

        public void CheckLections()
        {
            foreach (var lectionPair in Lections)
            {
                var lection = lectionPair.Key;

                CH.WriteSeparator();
                // TODO Очень какая-то сложная строка. Стоило вынести все строки тут  в константы и работать с переменными которые вы вставляли.
                Console.WriteLine($"{lection.Type} lection \"{lection.Theme}\" is held { (lection.Type == Knowledge.PhysicalEducation ? "at the univercity stadion": $"in classroom #{lection.Classroom}") }");
                CH.WriteSeparator();

                var humansOnLection = lectionPair.Value;

                foreach (var human in humansOnLection)
                {
                    // TODO Оставлю тут немного С# 7.0
                    switch (human)
                    {
                        case Student student:
                            student.Learn(lection.Type);
                            break;
                        case Lecturrer lecturrer:
                            lecturrer.Work(lection.Type);
                            break;
                        default:
                            Console.Write($"{human} is eating. ");
                            human.Eat();
                            break;
                    }
                    //if(human is Student student) student.Learn(lection.Type);
                    //else if(human is Lecturrer lecturrer) lecturrer.Work(lection.Type);
                    //else
                    //{
                    //    Console.Write($"{human.ToString()} is eating. ");
                    //    human.Eat();
                    //}
                }
            }
        }
    }
}