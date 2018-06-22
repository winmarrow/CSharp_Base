using SharedLib.Interfaces;

namespace SharedLib.Abstract
{
    public abstract class Logger : ILogger
    {
        public void Log(string message, bool withDateTime = true)
        {
            Log(LogChanel.Usual, message, withDateTime);
        }

        public void LogInfo(string message, bool withDateTime = true)
        {
            Log(LogChanel.Info, message, withDateTime);
        }

        public void LogError(string message, bool withDateTime = true)
        {
            Log(LogChanel.Error, message, withDateTime);
        }

        protected abstract void Log(LogChanel chanel, string message, bool withDateTime);

        protected enum LogChanel
        {
            Usual,
            Info,
            Error
        }
    }
}