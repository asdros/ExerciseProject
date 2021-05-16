using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; protected set; }
        [Required]
        public string Username { get; protected set; }
        [Required]
        public string Email { get; protected set; }
        [Required]
        public string Password { get; protected set; }
        [Required]
        public string Salt { get; protected set; }
        public DateTime RegistrationOn { get; protected set; }

        public User(Guid userID, string username, string email, string password, string salt)
        {
            ID = userID;
            SetUsername(username);
            SetEmail(email);
            SetPassword(password, salt);
            RegistrationOn = DateTime.UtcNow;
        }

        private void SetUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Username can not be empty.");
            }

            Username = username;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (Email == email)
            {
                return;
            }
            Email = email;
        }

        private void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }
            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
        }

    }
}
