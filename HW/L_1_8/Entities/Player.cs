using System;
using System.Threading;
using SharedLib.Helpers;

namespace L_1_8.Entities
{
    public class Player
    {
        public void PlayAlbum(Album album)
        {
            PlayAlbum(album, 0, album.Songs.Count);
        }

        public void PlayAlbum(Album album, int fromSongIndex)
        {
            PlayAlbum(album, fromSongIndex, album.Songs.Count);
        }

        public void PlayAlbum(Album album, int fromSongIndex, int toSongIndex)
        {
            ConsoleHelper.WriteSeparator();
            WriteAlbumInfo(album);
            ConsoleHelper.WriteSeparator();
            Console.WriteLine($"Playing album - {album.Title} from {fromSongIndex + 1} to {toSongIndex + 1}");
            ConsoleHelper.WriteSeparator();

            for (var i = fromSongIndex; i < toSongIndex; i++)
            {
                Console.Write($"#{i}: ");
                WriteSongInfo(album[i]);
                PlaySong(album[i]);

                Thread.Sleep(200);
            }
        }

        private void PlaySong(Song song)
        {
            Console.Beep(song.Frequency, song.Duration);
        }

        private void WriteAlbumInfo(Album album)
        {
            var duration = 0;
            foreach (var song in album.Songs)
                duration += song.Duration;

            Console.WriteLine("Album \"{0}\": {1} - Songs : All songs duration is {2} s", album.Title,
                album.Songs.Count, duration / 1000);
        }

        private void WriteSongInfo(Song song)
        {
            Console.WriteLine("{0} - \"{1}\": {2} mc",
                song.Band,
                song.Title,
                song.Duration);
        }
    }
}