using System.Collections.Generic;

namespace SrtWordCount
{
    public interface ISrtWordCountService
    {
        /// <summary>
        /// Gets statistics of a srt file.
        /// </summary>
        /// <param name="paths">A path of a file.</param>
        /// <returns><see cref="SrtStatistics"/>of a files.</returns>
        SrtStatistics GetSrtStatisticsOneFile(string paths);

        /// <summary>
        /// Gets statistics of srt files.
        /// </summary>
        /// <param name="paths">A list of paths of multi-files.</param>
        /// <returns>A list of <see cref="SrtStatistics"/> of multi-files.</returns>
        IEnumerable<SrtStatistics> GetSrtStatisticsMultiFiles(string[] paths);

        /// <summary>
        /// Gets all distinct words from multi-files.
        /// </summary>
        /// <param name="paths">List of all file paths.</param>
        /// <returns>A list of <see cref="WordCount"/> of distince words in multi-files.</returns>
        IEnumerable<WordCount> GetDistinctWordsMultiFiles(string[] paths);

        /// <summary>
        /// Gets all distinct words which are exist across multi-files.
        /// </summary>
        /// <param name="paths">List of all file paths.</param>
        /// <returns>List of <see cref="WordCount"/> of distince words exist across multi-files.</returns>
        IEnumerable<WordCount> GetDistinctWordsExistAcrossMultiFiles(string[] paths);

        /// <summary>
        /// Checks a word if it exists in all files.
        /// </summary>
        /// <param name="word">A word.</param>
        /// /// <param name="paths">List of all file paths.</param>
        /// <returns>A value indicates whether it exists or not.</returns>
        bool IsWordExistInMultiFiles(string word, string[] paths);
    }
}
