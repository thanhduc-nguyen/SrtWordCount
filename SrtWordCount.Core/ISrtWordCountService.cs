namespace SrtWordCount
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
    }
}
