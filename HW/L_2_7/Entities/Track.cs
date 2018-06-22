using System;
using System.IO;

namespace L_2_7.Entities
{
    [Serializable]
    public class Track : BaseEntity
    {
        private readonly string _filePath;


        public Track(string filePath, string title, string band, TimeSpan duration) : base(title)
        {
            _filePath = filePath;

            Band = band;
            Duration = duration;
        }

        public string Band { get; set; }
        public TimeSpan Duration { get; protected set; }

        public bool IsExist => File.Exists(_filePath);
    }
}