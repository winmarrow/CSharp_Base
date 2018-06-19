using System;
using SharedLib.Abstract;

namespace SharedLib.ConsoleHelpers
{
    public sealed class ConsoleLogger: Logger
    {
        private const string LogMsgTemplate = "[{0:dd/mm/yy|hh:mm:ss}|{1,5}] {2}";

        protected override void Log(LogChanel chanel, string message, bool withDateTime)
        {
            switch (chanel)
            {
                case LogChanel.Usual:
                    Console.ForegroundColor = Settings.ConsoleOutputColor; break;
                case LogChanel.Info:
                    Console.ForegroundColor = Settings.ConsoleInfoColor; break;
                case LogChanel.Error:
                    Console.ForegroundColor = Settings.ConsoleErrorColor; break;
            }

            Console.WriteLine(
                withDateTime ? LogMsgTemplate : message, 
                DateTime.Now, 
                chanel.ToString(),
                message);

            Console.ResetColor();
        }
    }
}