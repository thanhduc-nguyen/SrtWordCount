using System.Collections.Generic;

namespace SrtWordCount.Core
{
    public class SrtStatistics
    {
        /// <summary>
        /// The movie title.
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// The genre of a movie.
        /// </summary>
        public MovieGenre Genre { get; set; }

        /// <summary>
        /// The published year of a movie.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The list of words in a movie (srt file).
        /// </summary>
        public List<string> Words { get; set; }

        /// <summary>
        /// The list of distinct words and their quantity in a movie (srt file).
        /// </summary>
        public List<KeyValuePair<string, int>> DistinctWordCounts { get; set; }
    }
}
