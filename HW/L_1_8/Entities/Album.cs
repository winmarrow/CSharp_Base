using System.Collections.Generic;

namespace L_1_8.Entities
{
    public class Album
    {
        public Album(string title = null)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "No name Album" : title;
            Songs = new List<Song>();
        }

        public List<Song> Songs { get; }
        public string Title { get; }

        public Song this[int index]
        {
            get
            {
                if (index < 0 || index > Songs.Count - 1) return null;
                return Songs[index];
            }
            set
            {
                if (index < 0 || index > Songs.Count - 1) return;
                Songs[index] = value;
            }
        }

        public bool AddSong(Song song)
        {
            if (song == null) return false;

            Songs.Add(song);
            return true;
        }

        public static bool IsValid(Album album)
        {
            return album != null && !string.IsNullOrWhiteSpace(album.Title);
        }
    }
}