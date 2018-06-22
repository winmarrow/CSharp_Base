using System;
using System.Text;
using SharedLib.Structs;

namespace SharedLib.Helpers
{
    public static class ConsoleHelper
    {
        private const string StringInputTemplate = "{0}: ";
        private const string ChoiceTemplate = "{0,3} {1}";

        #region Cleaner

        public static void ClearLine(int lines = 1)
        {
            for (var i = 1; i <= lines; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        #endregion

        #region Getter

        public static string GetStringFromConsole(string message, ConsoleColor color = Settings.ConsoleInputColor)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                SetConsoleColor();
                Console.Write(StringInputTemplate, message);
            }

            var previosColor = Console.ForegroundColor;
            SetConsoleColor(color);

            var tempString = Console.ReadLine();

            SetConsoleColor(previosColor);

            return tempString;
        }

        #endregion


        #region Draw Rectangle

        public static void DrawRect(Position topLeftPosition, Size innerSize, ConsoleColor color = ConsoleColor.White,
            char backgroundChar = ' ')
        {
            var borderTopBottomChar = '═';
            var borderLeftRightChar = '║';

            var borderTopStr = $"╔{new string(borderTopBottomChar, innerSize.Width)}╗";
            var borderLineStr =
                $"{borderLeftRightChar}{new string(backgroundChar, innerSize.Width)}{borderLeftRightChar}";
            var borderBottompStr = $"╚{new string(borderTopBottomChar, innerSize.Width)}╝";

            SetConsoleColor(color);

            var lastCursorPosition = new Position(Console.CursorLeft, Console.CursorTop);

            Console.SetCursorPosition(topLeftPosition.Left, topLeftPosition.Top);
            Console.Write(borderTopStr);

            var lastLine = topLeftPosition.Top + innerSize.Height;

            while (Console.CursorTop < lastLine)
            {
                Console.SetCursorPosition(topLeftPosition.Left, ++Console.CursorTop);
                Console.Write(borderLineStr);
            }

            Console.SetCursorPosition(topLeftPosition.Left, ++Console.CursorTop);
            Console.Write(borderBottompStr);

            Console.SetCursorPosition(lastCursorPosition.Left, lastCursorPosition.Top);

            Console.ResetColor();
        }

        #endregion


        public static void SetConsoleOutputEncoding(Encoding encoding = null)
        {
            Console.OutputEncoding = encoding ?? Encoding.UTF8;
        }

        public static void SetConsoleColor(ConsoleColor color = Settings.ConsoleOutputColor)
        {
            Console.ForegroundColor = color;
        }

        #region Separator

        private static string _separatorString;

        public static string SeparatorString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_separatorString) || _separatorString.Length != Console.BufferWidth)
                    _separatorString = new string(Settings.SeparatorChar, Console.BufferWidth);

                return _separatorString;
            }
        }

        public static void WriteSeparator(ConsoleColor color = Settings.ConsoleOutputColor)
        {
            var previosColor = Console.ForegroundColor;
            SetConsoleColor(color);

            Console.Write(SeparatorString);

            SetConsoleColor(previosColor);
        }

        #endregion

        #region Asker

        public static TEnum GetChoiceFromUser<TEnum>(bool removeAfterChoice = false) where TEnum : struct
        {
            var enumType = typeof(TEnum);

            if (!enumType.IsEnum || Enum.GetValues(enumType).Length < 2)
                throw new ArgumentException("Type parameter must be an enum with two items", nameof(TEnum));

            var enumValues = Enum.GetNames(typeof(TEnum));
            return (TEnum) Enum.Parse(typeof(TEnum), GetChoiceFromUser(enumValues, removeAfterChoice).ChoisedString);
        }

        public static ChoiceResult GetChoiceFromUser(string[] choices, bool removeAfterChoice = false,
            bool canBeReject = false)
        {
            Console.CursorVisible = false;

            WriteSeparator();

            if (canBeReject)
            {
                Console.WriteLine("Use Escape button to reject this choice");
                WriteSeparator();
            }

            var currentIndex = 0;
            var topCursorPosition = Console.CursorTop;

            do
            {
                Console.SetCursorPosition(0, topCursorPosition);

                for (var i = 0; i < choices.Length; i++)
                    Console.WriteLine(ChoiceTemplate, currentIndex == i ? "=>" : string.Empty, choices[i]);

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) currentIndex = --currentIndex < 0 ? choices.Length - 1 : currentIndex;
                else if (key == ConsoleKey.DownArrow) currentIndex = ++currentIndex % choices.Length;
                else if (key == ConsoleKey.RightArrow || key == ConsoleKey.Enter) break;
                else if (canBeReject && key == ConsoleKey.Escape)
                    return new ChoiceResult(-1, string.Empty, true);
            } while (true);

            if (removeAfterChoice) ClearLine(choices.Length + (canBeReject ? 3 : 1));

            Console.CursorVisible = true;
            return new ChoiceResult(currentIndex, choices[currentIndex]);
        }

        #endregion
    }
}