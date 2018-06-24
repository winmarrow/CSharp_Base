using System;
using System.Collections.Generic;
using System.IO;
using L_2_7.Entities;
using L_2_7.Interfaces;
using CH = SharedLib.Helpers.ConsoleHelper;

namespace L_2_7
{
    // TODO Эх... даже не дали ничего про комментировать то...
    internal class Program
    {
        private static string MusicLibraryDir => "MusicLibrary\\Albums";

        private static void Main(string[] args)
        {
            CH.SetConsoleColor();
            CH.SetConsoleOutputEncoding();

            var tracks = new List<Track>
            {
                new Track("SomeFilePath0", "Track #0", "Some Band", new TimeSpan(1, 0, 0, 0)),
                new Track("SomeFilePath0", "Track #1", "Some Band", new TimeSpan(0, 1, 0, 0)),
                new Track("SomeFilePath0", "Track #2", "Some Band", new TimeSpan(0, 0, 1, 0)),
                new Track("SomeFilePath0", "Track #3", "Some Band", new TimeSpan(0, 0, 0, 1))
            };
            var labum = new Album("Album which will be serialized", new LinkedList<Track>(tracks));

            IAlbumSerializer serializer = new BinaryAlbumSerializer(MusicLibraryDir);

            Console.WriteLine("Saving into file:");

            var filePath = serializer.SaveToFile(labum);

            Console.WriteLine($"Labum was successfully saved. FilePath: {filePath}");
            CH.WriteSeparator();
            Console.ReadKey();

            Console.WriteLine("Loading from file:");

            var labumFromFile = serializer.LoadFromFile(filePath);

            CheckAlbum(labumFromFile);
            CH.WriteSeparator();
            Console.ReadKey();

            Console.WriteLine("Loading from BinaryArray:");

            var buffer = File.ReadAllBytes(filePath);
            var labumFromBinaryArray = serializer.LoadFromBinaryArray(buffer);

            CheckAlbum(labumFromBinaryArray);
            CH.WriteSeparator();
            Console.ReadKey();
        }


        private static void CheckAlbum(Album album)
        {
            if (album != null)
                Console.WriteLine($"Labum was successfully loaded.");
            else
                Console.WriteLine($"Something went wrong.");
        }
    }
}