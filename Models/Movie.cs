using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProject.Models
{
    public class Movie
    {
        [Key]
        public Guid ID { get; protected set; }
        [Required]
        public string Title { get; protected set; }
        [Required]
        public ushort YearOfProduction { get; protected set; }
        [Required]
        public Soundtrack OriginalSoundtrack { get; protected set; }
        [Required]
        public Genre Genre { get; protected set; }
        [Required]
        [ForeignKey("Director")]
        public int DirectorID { get; protected set; }
        public string Description { get; protected set; }
        public string OtherTitles { get; protected set; }
        // public byte[] Image { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<Subtitles> Subtitles { get; set; }

        public Movie()
        {

        }

        public Movie(Guid movieID, string title, ushort yearOfProduction, Soundtrack originalSoundtrack,
            Genre genre, int directorID, string description, string otherTitles)
        //byte[] image)
        {
            ID = movieID;
            SetTitle(title);
            SetYearOfProduction(yearOfProduction);
            SetOriginalSoundTrack(originalSoundtrack);
            SetGenre(genre);
            SetDirector(directorID);
            SetDescription(description);
            SetOtherTitles(otherTitles);
            // SetImage(image);
            CreatedAt = DateTime.UtcNow;
        }

        //private void SetImage(byte[] image)
        //{
        //    if (image == null && image.Length <= 0)
        //    {
        //        throw new Exception("Image is not incorrect.");
        //    }
        //    Image = image;
        //}

        private void SetOtherTitles(string otherTitles)
        {
            if (string.IsNullOrEmpty(otherTitles))
            {
                throw new Exception("Title can not be empty.");
            }

            OtherTitles = otherTitles;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Description can not be empty.");
            }

            Description = description;
        }

        private void SetDirector(int directorID)
        {
            DirectorID = directorID;
        }

        private void SetGenre(Genre genre)
             => Genre = genre;


        private void SetOriginalSoundTrack(Soundtrack originalSoundtrack)
        {
            OriginalSoundtrack = originalSoundtrack;
        }

        private void SetYearOfProduction(ushort yearOfProduction)
        {
            if (yearOfProduction < 1000)
            {
                throw new Exception("Year of production is incorrect.");
            }

            YearOfProduction = yearOfProduction;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("Title can not be empty.");
            }

            Title = title;
        }
    }
}
