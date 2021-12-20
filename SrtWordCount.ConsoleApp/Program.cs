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
            var movieName = Path.GetFileName(path).Replace(".srt", "");

            var data = _srtWordCountService.AnalyzeSrtStatistics(movieName, text);

            Console.WriteLine($"{data.MovieName} is a { data.Genre} movie which has {data.DistinctWordCountList.Count} words.");
        }
    }
}
