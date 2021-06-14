using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class Director
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(50, ErrorMessage = "Firstname is too long (50 characters limit).")]
        [MinLength(2, ErrorMessage = "Firstname is too short (2 characters minimum).")]
        public string Firstname { get;  set; }
        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname is too long (50 characters limit).")]
        [MinLength(2, ErrorMessage = "Surname is too short (2 characters minimum).")]
        public string Surname { get;  set; }
    }
}