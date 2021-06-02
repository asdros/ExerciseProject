using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class Director
    {
        public Guid ID { get; set; }
        public string Firstname { get;  set; }
        public string Surname { get;  set; }
    }
}