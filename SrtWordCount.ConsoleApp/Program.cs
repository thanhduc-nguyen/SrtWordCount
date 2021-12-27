using SrtWordCount.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SrtWordCount.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISrtWordCountService _srtWordCountService = new SrtWordCountService();

            var path = $"{Environment.CurrentDirectory}\\SrtFiles\\Back to the Future 1985.srt";
            string text = File.ReadAllText(path);
            var movieTitle = Path.GetFileName(path).Replace(".srt", "");

            var path2 = $"{Environment.CurrentDirectory}\\SrtFiles\\Interstellar 2014.srt";
            string text2 = File.ReadAllText(path2);
            var movieTitle2 = Path.GetFileName(path2).Replace(".srt", "");

            var data = _srtWordCountService.AnalyzeSrtStatistics(movieTitle, text);
            data.Genre = MovieGenre.SciFi;

            var data2 = _srtWordCountService.AnalyzeSrtStatistics(movieTitle2, text2);
            data2.Genre = MovieGenre.SciFi;

            var result = _srtWordCountService.GetAllDistinctWordsByGenre(new List<SrtStatistics> { data, data2 }, MovieGenre.SciFi);

            Console.WriteLine($"{data.MovieTitle} is a { data.Genre} movie which has {data.DistinctWordCounts.Count} words.");
            Console.WriteLine($"{data2.MovieTitle} is a { data2.Genre} movie which has {data2.DistinctWordCounts.Count} words.");
            Console.WriteLine($"Total distinct words for {MovieGenre.SciFi} movies are {result.Count()} words.");
        }
    }
}
