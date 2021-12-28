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

            string text;
            string fileName;
            string[] fileNameInfo;
            SrtStatistics data;

            foreach (var path in Directory.GetFiles($"{ Environment.CurrentDirectory}\\SrtFiles\\", "*.srt"))
            {
                text = File.ReadAllText(path);
                fileName = Path.GetFileName(path);
                fileNameInfo = fileName.Split(" ");
                data = _srtWordCountService.AnalyzeSrtStatistics(fileName, text);

                Console.WriteLine($"{data.MovieTitle} is a {data.Genre} movie which has {data.DistinctWordCounts.Count} words and were published in {data.Year}.");
            }
        }
    }
}
