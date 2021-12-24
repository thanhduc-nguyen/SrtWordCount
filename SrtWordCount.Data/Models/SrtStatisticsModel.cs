using SrtWordCount.Core;
using System.ComponentModel.DataAnnotations;

namespace SrtWordCount.Data.Models
{
    public class SrtStatisticsModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Movie title")]
        [MaxLength(250, ErrorMessage = "Max length is 80 characters")]
        public string MovieTitle { get; set; }

        public MovieGenre Genre { get; set; }
        public string Words { get; set; }
        public string DistinctWordCounts { get; set; }
    }
}
