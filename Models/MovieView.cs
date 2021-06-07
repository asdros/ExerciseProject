using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class MovieView : MovieDirector
    {
        [Key]
        public Guid IdFile { get; set; }
#nullable enable
        public string? Filename { get; set; }
        public byte[]? FileData { get; set; }
#nullable disable

    }
}
