using System;
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

            var fileNameInfo = fileName.Replace(".srt", "").Split(" ").ToList();
            if (Enum.TryParse(fileNameInfo[0].Substring(1, fileNameInfo[0].Length - 2), true, out MovieGenre genre))
            {
                srtStatistics.Genre = genre;
            }
            else
            {
                srtStatistics.Genre = MovieGenre.None;
            }

            if (int.TryParse(fileNameInfo.LastOrDefault(), out int year))
            {
                srtStatistics.Year = year;
            }
            else
            {
                srtStatistics.Year = 0;
            }
            fileNameInfo.RemoveAt(0);
            fileNameInfo.RemoveAt(fileNameInfo.Count - 1);
            srtStatistics.MovieTitle = string.Join(" ", fileNameInfo);

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
    }
}
