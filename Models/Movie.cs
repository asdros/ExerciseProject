using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title is too long (200 characters limit).")]
        [MinLength(2, ErrorMessage = "Title is too short (2 characters minimum).")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year of production is required.")]
        [Range(1900, 2100, ErrorMessage = "Year invalid (1900 - 2100).")]
        public int YearOfProduction { get; set; }
        [Required(ErrorMessage = "Language of soundtrack is required.")]
        public string OriginalSoundtrack { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        public Guid DirectorID { get; set; }
        [StringLength(2000, ErrorMessage = "Description is too long (2000 characters limit).")]
        [MinLength(10, ErrorMessage = "Description is too short (10 characters minimum).")]
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Titles are too long (100 characters limit).")]
        [MinLength(2, ErrorMessage = "Title is too short (2 characters minimum).")]
        public string OtherTitles { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PosterID { get; set; }
    }
}
