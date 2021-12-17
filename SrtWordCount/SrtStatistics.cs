using System.Collections.Generic;

namespace SrtWordCount
{
    public class SrtStatistics
    {
        /// <summary>
        /// File name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// List of words in a srt file.
        /// </summary>
        public List<string> Words { get; set; } = new List<string>();

        /// <summary>
        /// List of distinct words and their quantity in a srt file.
        /// </summary>
        public List<WordCount> DistinctWordCountList { get; set; } = new List<WordCount>();
    }
}
