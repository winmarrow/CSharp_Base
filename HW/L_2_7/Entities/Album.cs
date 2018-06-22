using System;
using System.Collections.Generic;
using System.Linq;

namespace L_2_7.Entities
{
    [Serializable]
    public class Album : BaseEntity
    {
        public Album() : this("Album without title")
        {
        }

        public Album(string title) : this(title, new LinkedList<Track>())
        {
        }

        public Album(string title, LinkedList<Track> tracks) : base(title)
        {
            Id = Guid.NewGuid();
            Tracks = tracks;
        }

        public Guid Id { get; }

        public LinkedList<Track> Tracks { get; }

        public IEnumerable<string> Bands => Tracks.Select(track => track.Band).Distinct();
    }
}