using System.Collections.Generic;

namespace SrtWordCount.Core
{
    public interface ISrtWordCountService
    {
        /// <summary>
        /// Analyzes the SRT statistics.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text.</param>
        /// <returns><see cref="SrtStatistics"/>of a files.</returns>
        SrtStatistics AnalyzeSrtStatistics(string fileName, string text);

        /// <summary>
        /// Gets all distinct words by genre.
        /// </summary>
        /// <param name="srtStatisticsList">The SRT statistics list.</param>
        /// <param name="genre">The movie genre.</param>
        /// <returns>A collection of <see cref="KeyValuePair"/> list to store words and their quantity which have the same genre.</returns>
        IEnumerable<KeyValuePair<string, int>> GetAllDistinctWordsByGenre(IEnumerable<SrtStatistics> srtStatisticsList, MovieGenre genre);
    }
}
