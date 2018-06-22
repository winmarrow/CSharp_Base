using L_2_7.Entities;

namespace L_2_7.Interfaces
{
    public interface ICanLoadAlbum
    {
        Album LoadFromFile(string fileName);
        Album LoadFromBinaryArray(byte[] buffer);
    }
}