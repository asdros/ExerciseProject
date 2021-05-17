using System;
using System.Collections.Generic;

namespace ExerciseProject.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public ushort YearOfProduction { get; set; }
        public string OriginalSoundtrack { get; set; }
        public string Genre { get; set; }
        public int DirectorID { get; set; }
        public string Description { get; set; }
        public string OtherTitles { get; set; }
        // public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<Subtitles> Subtitles { get; set; }

    }
}
