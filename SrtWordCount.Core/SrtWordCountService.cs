using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SrtWordCount
{
    public class SrtWordCountService : ISrtWordCountService
    {
        public SrtStatistics AnalyzeSrtStatistics(string fileName, string text)
        {
            var srtStatistics = new SrtStatistics();
            var allWordsInSrt = new List<string>();

            string[] allLinesInSrt = Regex.Split(text, @"(?:\r?\n)*\d+\r?\n\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\r?\n");

            srtStatistics.MovieName = fileName;

            foreach (var item in allLinesInSrt)
            {
                //Get IEnumerable of words
                var wordsInSrtLine = from Match match in Regex.Matches(item, @"\b\S+\b")
                                     select match.Value;
                allWordsInSrt.AddRange(wordsInSrtLine.Select(x => x.ToLower()));
            }

            foreach (var line in allWordsInSrt.GroupBy(info => info)
                           .Select(group => new WordCount
                           {
                               Word = group.Key,
                               Count = group.Count()
                           })
                           .OrderByDescending(x => x.Count))
            {
                srtStatistics.DistinctWordCountList.Add(line);
            }

            srtStatistics.Words = allWordsInSrt;

            return srtStatistics;
        }
    }
}
