using System.IO;
using L_2_7.Entities;
using L_2_7.Interfaces;
using SharedLib.Helpers;

namespace L_2_7.Absractions
{
    public abstract class AlbumSerializer : IAlbumSerializer
    {
        private readonly string _workDirectory;

        protected AlbumSerializer(string workDirectory)
        {
            _workDirectory = workDirectory;
            StreamHelpers.CheckDir(_workDirectory);
        }

        public Album LoadFromFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName)) return null;

            using (var fileStream = File.Open(fileName, FileMode.Open))
            {
                return Deserialize(fileStream);
            }
        }

        public Album LoadFromBinaryArray(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;

            return Deserialize(new MemoryStream(buffer));
        }

        public string SaveToFile(Album album)
        {
            if (album == null) return string.Empty;

            var fileName = Path.Combine(_workDirectory, GetFileName(album));

            using (var fileStream = File.Open(fileName, FileMode.Create, FileAccess.Write))
            {
                Serialize(album, fileStream);
            }

            return fileName;
        }

        protected abstract string GetFileName(Album album);
        protected abstract void Serialize(Album album, Stream outputStream);
        protected abstract Album Deserialize(Stream inputStream);
    }
}