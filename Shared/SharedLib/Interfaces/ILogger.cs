namespace SharedLib.Interfaces
{
    public interface ILogger
    {
        void Log(string message, bool withDateTime = true);
        void LogError(string message, bool withDateTime = true);
        void LogInfo(string message, bool withDateTime = true);
    }
}