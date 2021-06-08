using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class UploadedFile 
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Filename { get; set; }
        [Required]
        public string FileData { get; set; }
    }
}
