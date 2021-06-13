using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class SubtitlesFile : Subtitles
    {
#nullable enable
        public string? Filename { get; set; }
        public string? FileData { get; set; }
#nullable disable

    }
}
