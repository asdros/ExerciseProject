using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class MovieView : MovieDirector
    {
#nullable enable
        [StringLength(100, ErrorMessage = "File name is too long (100 characters limit).")]
        public string? Filename { get; set; }
        public string? FileData { get; set; }
#nullable disable

    }
}
