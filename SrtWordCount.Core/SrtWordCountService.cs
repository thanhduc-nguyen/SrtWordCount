using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SrtWordCount.Core
{
    public class SrtWordCountService : ISrtWordCountService
    {
        public SrtStatistics AnalyzeSrtStatistics(string fileName, string text)
        {
            var srtStatistics = new SrtStatistics();
            var allWordsInSrt = new List<string>();

            string[] allLinesInSrt = Regex.Split(text, @"(?:\r?\n)*\d+\r?\n\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\r?\n");

            srtStatistics.MovieTitle = fileName.Replace(".srt", "");

            foreach (var item in allLinesInSrt)
            {
                //Get IEnumerable of words
                var wordsInSrtLine = from Match match in Regex.Matches(item, @"\b\S+\b")
                                     select match.Value;
                allWordsInSrt.AddRange(wordsInSrtLine.Select(x => x.ToLower()));
            }

            srtStatistics.DistinctWordCounts = new List<KeyValuePair<string, int>>();

            foreach (var line in allWordsInSrt.GroupBy(info => info)
                           .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()))
                           .OrderByDescending(x => x.Value))
            {
                srtStatistics.DistinctWordCounts.Add(line);
            }

            srtStatistics.Words = allWordsInSrt;
            return srtStatistics;
        }

        public IEnumerable<KeyValuePair<string, int>> GetAllDistinctWordsByGenre(IEnumerable<SrtStatistics> srtStatisticsList, MovieGenre genre)
        {
            var data1 = srtStatisticsList.Where(x => x.Genre == genre).Select(x => x.Words);
            var data2 = new List<string>();
            var result = new List<KeyValuePair<string, int>>();
            foreach (var item in data1)
            {
                data2.AddRange(item);
            }
            foreach (var line in data2.GroupBy(info => info)
                           .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()))
                           .OrderByDescending(x => x.Value))
            {
                result.Add(line);
            }
            return result;
        }
    }
}
