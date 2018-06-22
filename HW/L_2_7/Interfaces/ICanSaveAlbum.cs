using L_2_7.Entities;

namespace L_2_7.Interfaces
{
    public interface ICanSaveAlbum
    {
        string SaveToFile(Album album);
    }
}