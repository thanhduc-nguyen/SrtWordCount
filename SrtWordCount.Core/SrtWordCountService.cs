using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SrtWordCount
{
    public class SrtWordCountService : ISrtWordCountService
    {
        public IEnumerable<SrtStatistics> GetSrtStatisticsMultiFiles(string[] paths)
        {
            foreach (var path in paths)
            {
                yield return GetSrtStatistics(path);
            }
        }

        public SrtStatistics GetSrtStatisticsOneFile(string path)
        {
            return GetSrtStatistics(path);
        }

        public IEnumerable<WordCount> GetDistinctWordsMultiFiles(string[] paths)
        {
            return AllDistinctWordsMultiFiles(paths);
        }

        public IEnumerable<WordCount> GetDistinctWordsExistAcrossMultiFiles(string[] paths)
        {
            var wordsInOneSrtList = new List<List<WordCount>>();
            foreach (var path in paths)
            {
                wordsInOneSrtList.Add(GetSrtStatistics(path).DistinctWordCountList);
            }

            // All words existing in all srt files
            var result = wordsInOneSrtList.Aggregate((wordCountList1, wordCountList2) =>
            {
                var temp = new List<WordCount>();
                for (int i = 0; i < wordCountList1.Count; i++)
                {
                    for (int j = 0; j < wordCountList2.Count; j++)
                    {
                        if (wordCountList1[i].Word.Equals(wordCountList2[j].Word, StringComparison.OrdinalIgnoreCase))
                        {
                            temp.Add(new WordCount { Word = wordCountList1[i].Word, Count = wordCountList1[i].Count + wordCountList2[j].Count });
                        }
                    }
                }
                return temp;
            });

            return result;
        }

        public bool IsWordExistInMultiFiles(string word, string[] paths)
        {
            var data = AllDistinctWordsMultiFiles(paths);
            return data.Select(x => x.Word).Any(y => y == word.ToLower());
        }

        private SrtStatistics GetSrtStatistics(string path)
        {
            var srtStatistics = new SrtStatistics();
            var allWordsInSrt = new List<string>();

            string inputText = File.ReadAllText(path);
            string[] allLinesInSrt = Regex.Split(inputText, @"(?:\r?\n)*\d+\r?\n\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\r?\n");

            srtStatistics.FileName = Path.GetFileName(path);

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

        private IEnumerable<WordCount> AllDistinctWordsMultiFiles(string[] paths)
        {
            var allSrtStatistics = new List<SrtStatistics>();
            foreach (var path in paths)
            {
                allSrtStatistics.Add(GetSrtStatistics(path));
            }
            var data1 = allSrtStatistics.Select(x => x.Words);
            var data2 = new List<string>();
            var result = new List<WordCount>();
            foreach (var item in data1)
            {
                data2.AddRange(item);
            }
            foreach (var line in data2.GroupBy(info => info)
                           .Select(group => new WordCount
                           {
                               Word = group.Key,
                               Count = group.Count()
                           })
                           .OrderByDescending(x => x.Count))
            {
                result.Add(line);
            }
            return result;
        }
    }
}
