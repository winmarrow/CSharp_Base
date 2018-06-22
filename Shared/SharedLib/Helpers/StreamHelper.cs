using System.IO;

namespace SharedLib.Helpers
{
    public static class StreamHelpers
    {
        public static void CheckDir(string dirName)
        {
            if (string.IsNullOrWhiteSpace(dirName))
                dirName = Directory.GetCurrentDirectory();
            
            var dInfo = new DirectoryInfo(dirName);
            if (!dInfo.Exists)
                dInfo.Create();
        }

        public static void CheckFileDir(string filename)
        {
            var dirName = Path.GetDirectoryName(filename);
            CheckDir(dirName);
        }
    }
}