using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class UploadFile
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string FileName { get; set; }
    }
}
