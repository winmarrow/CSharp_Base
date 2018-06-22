using System;
using System.Collections.Generic;
using L_2_3.Interfaces;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_3.Entities
{
    public class Field
    {
        private readonly List<IAnimal> _rabbits;
        private readonly List<IAnimal> _tigers;
        private int _grassCount;

        public Field(int width, int height)
        {
            _rabbits = new List<IAnimal>();
            _tigers = new List<IAnimal>();

            _grassCount = width * height * 2;
        }

        public void GenerateNewAnimals(int rabbitCount, int tigerCount)
        {
            _rabbits.Clear();
            _tigers.Clear();

            for (var i = 0; i < rabbitCount; i++)
                _rabbits.Add(new Rabbit());

            for (var i = 0; i < tigerCount; i++)
                _tigers.Add(new Tiger());
        }

        // TODO Слишком большой метод. Стоило добавить класс GameActions и там распилить этот метод.
        public void NextStep()
        {
            var deadRabbits = new List<IAnimal>();
            var deadTigers = new List<IAnimal>();

            foreach (var rabbit in _rabbits)
            {
                if (rabbit.IsHunger)
                    if (_grassCount > 0)
                    {
                        _grassCount--;
                        rabbit.Eat();
                        rabbit.Sleep();
                    }
                    else
                    {
                        deadRabbits.Add(rabbit);
                    }

                rabbit.Sleep();
                // TODO Голодный кролик после того как поест спит 2 раза.
            }

            foreach (var deadRabbit in deadRabbits)
                _rabbits.Remove(deadRabbit);

            // TODO Вот тут есть копипаст. Но чтобы от него избавиться надо постараться сделать логику более общее.
            // у вас есть животные и их вкусовые предпочтения - Если что-то на клетке отвечает этим предпочтениям, то можно кушать
            foreach (var tiger in _tigers)
            {
                if (tiger.IsHunger)
                    if (deadRabbits.Count > 0)
                    {
                        deadRabbits.RemoveAt(deadRabbits.Count - 1);
                        tiger.Eat();
                    }
                    else if (_rabbits.Count > 0)
                    {
                        _rabbits.RemoveAt(_rabbits.Count - 1);
                        tiger.Eat();
                    }
                    else
                    {
                        deadTigers.Add(tiger);
                    }

                tiger.Sleep();
            }

            foreach (var deadTiger in deadTigers) _tigers.Remove(deadTiger);

            var rabbitPairs = _rabbits.Count / 2;
            for (var i = 0; i < rabbitPairs; i++) _rabbits.Add(new Rabbit());

            var tigerPairs = _tigers.Count;
            for (var i = 0; i < tigerPairs / 2; i++) _tigers.Add(new Tiger());

            _grassCount += _grassCount / 10 + 10 * deadTigers.Count;

            WriteFieldStatus();
        }

        private void WriteFieldStatus()
        {
            CH.WriteSeparator();
            Console.WriteLine(
                $"On field:\n -Grass count {_grassCount}\n -Rabbits count: {_rabbits.Count}\n -Tigers count: {_tigers.Count}");
            if (_rabbits.Count == 0 && _tigers.Count == 0)
                Console.WriteLine("\tAll dead");
        }
    }
}