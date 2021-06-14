using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class Subtitles
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title is too long (100 characters limit).")]
        [MinLength(2, ErrorMessage = "Title is too short (2 characters minimum).")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Description is too long (500 characters limit).")]
        [MinLength(10, ErrorMessage = "Description is too short (10 characters minimum).")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Language is required.")]
        public string Language { get; set; }
        [Required]
        public Guid MovieID { get; set; }
        public DateTime AddedOn { get; set; }
        [Required]
        public Guid SubtitlesFileId { get; set; }
    }
}
