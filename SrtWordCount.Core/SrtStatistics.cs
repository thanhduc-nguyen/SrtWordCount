using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SrtWordCount
{
    public class SrtStatistics
    {
        /// <summary>
        /// The identity of a srt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The file name of a srt (movie name).
        /// </summary>
        [Required, StringLength(100)]
        [Display(Name = "Movie name")]
        public string MovieName { get; set; }

        /// <summary>
        /// The genre of a movie.
        /// </summary>
        public MovieGenre Genre { get; set; } = MovieGenre.None;

        /// <summary>
        /// The list of words in a movie (srt file).
        /// </summary>
        public List<string> Words { get; set; } = new List<string>();

        /// <summary>
        /// The list of distinct words and their quantity in a movie (srt file).
        /// </summary>
        public List<WordCount> DistinctWordCountList { get; set; } = new List<WordCount>();
    }
}
