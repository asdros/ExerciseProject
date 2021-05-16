using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models
{
    public class Director
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Firstname { get; protected set; }
        [Required]
        public string Surname { get; protected set; }

        public Director(Guid directorID, string firstname, string surname)
        {
            ID = directorID;
            SetFirstname(firstname);
            SetSurname(surname);
        }

        private void SetFirstname(string firstname)
        {
            if (String.IsNullOrEmpty(firstname))
            {
                throw new Exception("Firstname can not be empty.");
            }

            Firstname = firstname;
        }

        private void SetSurname(string surname)
        {
            if (String.IsNullOrEmpty(surname))
            {
                throw new Exception("Surname can not be empty.");
            }

            Surname = surname;
        }
    }
}