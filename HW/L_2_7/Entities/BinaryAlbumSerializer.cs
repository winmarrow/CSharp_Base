using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using L_2_7.Absractions;

namespace L_2_7.Entities
{
    public class BinaryAlbumSerializer : AlbumSerializer
    {
        public BinaryAlbumSerializer(string workDirectory) : base(workDirectory)
        {
        }

        protected override string GetFileName(Album album)
        {
            return $"Album-{album.Id}.bin";
        }

        protected override void Serialize(Album album, Stream outputStream)
        {
            new BinaryFormatter().Serialize(outputStream, album);
        }

        protected override Album Deserialize(Stream inputStream)
        {
            return new BinaryFormatter().Deserialize(inputStream) as Album;
        }
    }
}