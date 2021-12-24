using SrtWordCount.Core;
using System;
using System.IO;

namespace SrtWordCount.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISrtWordCountService _srtWordCountService = new SrtWordCountService();

            var path = $"{Environment.CurrentDirectory}\\SrtFiles\\The Boss Baby 2017.srt";
            string text = File.ReadAllText(path);
            var movieTitle = Path.GetFileName(path).Replace(".srt", "");

            var path2 = $"{Environment.CurrentDirectory}\\SrtFiles\\Hitch 2005.srt";
            string text2 = File.ReadAllText(path2);
            var movieTitle2 = Path.GetFileName(path2).Replace(".srt", "");

            var data = _srtWordCountService.AnalyzeSrtStatistics(movieTitle, text);
            data.Genre = MovieGenre.Children;

            var data2 = _srtWordCountService.AnalyzeSrtStatistics(movieTitle2, text2);
            data2.Genre = MovieGenre.Drama;

            Console.WriteLine($"{data.MovieTitle} is a { data.Genre} movie which has {data.DistinctWordCountList.Count} words.");
            Console.WriteLine($"{data2.MovieTitle} is a { data2.Genre} movie which has {data2.DistinctWordCountList.Count} words.");
        }
    }
}
