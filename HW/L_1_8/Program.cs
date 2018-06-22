using System;
using System.Collections.Generic;
using L_1_8.Entities;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            var songs = new List<Song>
            {
                new Song("Super Band", "Super Song"),
                new Song(title: "Super Song"),
                new Song("Super Band"),
                new Song("Giper Band", "Awful Song"),
                new Song("Super Band", "Super Song"),
                new Song("Just Band", "Isn't Song"),
                new Song("Band of justice", "Super Song"),
                new Song(),
                new Song("My", "First SOng", 500, 300),
                new Song("My", "Second song", 1500, 700)
            };

            var myFirstAlbum = new Album("My First Album"); // or new Album();
            foreach (var song in songs)
                myFirstAlbum.AddSong(song);

            var player = new Player();

            var rand = new Random(DateTime.Now.Second);

            Console.Write($"We are ready to play All album ({myFirstAlbum.Songs.Count})");
            Console.ReadKey();
            player.PlayAlbum(myFirstAlbum);

            var from = rand.Next(0, myFirstAlbum.Songs.Count);
            Console.WriteLine(Environment.NewLine);
            Console.Write($"We are ready to play from song #{from + 1} to end of album");
            Console.ReadKey();
            player.PlayAlbum(myFirstAlbum, from);

            from = rand.Next(0, myFirstAlbum.Songs.Count);
            var to = rand.Next(from, myFirstAlbum.Songs.Count);
            Console.WriteLine(Environment.NewLine);
            Console.Write($"We are ready to play album from song #{from + 1} to #{to + 1} song");
            Console.ReadKey();
            player.PlayAlbum(myFirstAlbum, from, to);

            Console.WriteLine("That is all. Goodbye");
            Console.ReadKey();
        }
    }
}