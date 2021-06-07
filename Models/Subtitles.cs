using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProject.Models
{
    public class Subtitles
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieID { get; set; }
        [Required]
        public DateTime AddedOn { get; set; }
        [ForeignKey("File")]
        public Guid SubtitlesFile { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
