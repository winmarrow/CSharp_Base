using System;
using System.Text;
using System.Threading;
using SharedLib.Structs;
using CH = SharedLib.Helpers.ConsoleHelper;

namespace L_1_5
{
    internal class Program
    {
        private const int LineSize = 20; //15; // длина бегущей строки, 15 маловато
        private const int SleepInterval = 150; //Интервал обновления

        private static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            Console.CursorVisible = false;

            //Varian_1_Old();
            Variant_2_New();
        }

        private static void Varian_1_Old()
        {
            const string timeMark = "{time}"; // так помечается место для времени
            const char borederTopChar = '_';
            const char borederBottomChar = '‾';
            const char borderLeftRightChar = '|';
            const char spaceChar = ' ';

            // С этими можно играться
            const char backgroundChar = '·'; // spaceChar; можно задать фон текста
            string[] strings = //выводимые строки
            {
                "Минское время {time}. ",
                "Говорят и показывают все телестанции страны... "
            };

            //Выводим рамку
            Console.WriteLine(new string(borederTopChar, LineSize + 2));
            Console.WriteLine("{0}{1}{0}", borderLeftRightChar, new string(backgroundChar, LineSize));
            Console.WriteLine(new string(borederBottomChar, LineSize + 2));

            //Забиваем все строки в буфер
            var buffer = new StringBuilder(new string(spaceChar, LineSize));
            foreach (var str in strings)
                buffer.Append(str);

            buffer.Replace(spaceChar, backgroundChar); //Устанавливаем символ для фона

            Console.ForegroundColor = ConsoleColor.DarkYellow; //Цвет текста
            var oldTime = timeMark;
            var currentPosition = 0;

            while (true)
            {
                //'Обновляем' время в буфере, если оно изменилось
                var newTime = DateTime.Now.ToLongTimeString();
                if (!newTime.Equals(oldTime))
                {
                    buffer.Replace(oldTime, newTime);
                    oldTime = newTime;
                }

                var charsToBufferEnd = buffer.Length - currentPosition; // Находим остаток до конца буфера

                Console.SetCursorPosition(1, 1); // прыгаем в начало бегущей стоки

                if (charsToBufferEnd >= LineSize) //если хватает то виыводим так
                {
                    Console.Write(buffer.ToString(currentPosition, LineSize));
                }
                else // если нет, то добисываем с начала буфера
                {
                    Console.Write(buffer.ToString(currentPosition, charsToBufferEnd));
                    Console.Write(buffer.ToString(0, LineSize - charsToBufferEnd));
                }

                Thread.Sleep(SleepInterval); //Поток спит
                currentPosition = ++currentPosition % buffer.Length; //Идём на следующий символ
            }
        }

        private static void Variant_2_New()
        {
            const string digitsTemolate = "##";
            const int digitsOffset = 48;

            const int offsetLeft = 20;
            const int offsetTop = 20;

            var timeString =
                $"Минское время {digitsTemolate}:{digitsTemolate}:{digitsTemolate}. Говорят и показывают все телестанции страны... "; //выводиая строка

            var buffer = timeString.ToCharArray();
            var hoursIndex = timeString.IndexOf(digitsTemolate);
            var munitsIndex = timeString.IndexOf(digitsTemolate, hoursIndex + 1);
            var secondsIndex = timeString.IndexOf(digitsTemolate, munitsIndex + 1);

            //Выводим рамку
            CH.DrawRect(new Position(offsetLeft - 1, offsetTop - 1), new Size(LineSize, 1));

            CH.SetConsoleColor(ConsoleColor.DarkYellow); //Цвет текста

            var currentPosition = 0;

            while (true)
            {
                //'Обновляем' время в буфере, если оно изменилось
                var newTime = DateTime.Now;

                buffer[hoursIndex] = newTime.Hour < 10 ? '0' : (char) (newTime.Hour / 10 + digitsOffset);
                buffer[hoursIndex + 1] = (char) (newTime.Hour % 10 + digitsOffset);

                buffer[munitsIndex] = newTime.Minute < 10 ? '0' : (char) (newTime.Minute / 10 + digitsOffset);
                buffer[munitsIndex + 1] = (char) (newTime.Minute % 10 + digitsOffset);

                buffer[secondsIndex] = newTime.Second < 10 ? '0' : (char) (newTime.Second / 10 + digitsOffset);
                buffer[secondsIndex + 1] = (char) (newTime.Second % 10 + digitsOffset);


                var charsToStringEnd = buffer.Length - currentPosition; // Находим остаток до конца буфера

                Console.SetCursorPosition(offsetLeft, offsetTop); // прыгаем в начало бегущей стоки

                if (charsToStringEnd >= LineSize) //если хватает то виыводим так
                {
                    Console.Write(buffer, currentPosition, LineSize);
                }
                else // если нет, то добисываем с начала буфера
                {
                    Console.Write(buffer, currentPosition, charsToStringEnd);
                    Console.Write(buffer, 0, LineSize - charsToStringEnd);
                }

                Thread.Sleep(SleepInterval); //Поток спит
                currentPosition = ++currentPosition % buffer.Length; //Идём на следующий символ
            }
        }
    }
}