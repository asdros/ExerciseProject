using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProject.Models
{
    public class Subtitles
    {
        [Key]
        public Guid ID { get; protected set; }
        [Required]
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        [Required]
        public Soundtrack Language { get; protected set; }
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieID { get; protected set; }
        [Required]
        [ForeignKey("User")]
        public Guid UserID { get; protected set; }
        [Required]
        public DateTime AddedOn { get; protected set; }
        public UploadFile SubtitlesFileName { get; protected set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }


        public Subtitles(Guid subtitlesID, string title, string description, Soundtrack language, Guid movieID, Guid userID, string subtitlesFileFormat, string subtitlesFileName)
        {
            ID = subtitlesID;
            SetTitle(title);
            SetDescription(description);
            // todo enum set
            MovieID = movieID;
            UserID = userID;
            // todo save object model from second table
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("Title can not be empty.");
            }

            Title = title;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Title can not be empty.");
            }

            Description = description;
        }
    }
}
