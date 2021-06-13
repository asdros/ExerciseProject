using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProject.Models
{
    public class Subtitles
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieID { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid SubtitlesFileId { get; set; }
    }
}
