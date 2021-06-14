using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class MovieView : MovieDirector
    {
#nullable enable
        [StringLength(50, ErrorMessage = "Firstname is too long (50 characters limit).")]
        public string? Filename { get; set; }
        public string? FileData { get; set; }
#nullable disable

    }
}
