using System;
using System.IO;
using System.Linq;

namespace SrtWordCount.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISrtWordCountService _srtWordCountService = new SrtWordCountService();

            var theBossBaby = _srtWordCountService.GetSrtStatisticsOneFile($"{Environment.CurrentDirectory}\\SrtFiles\\The Boss Baby 2017.srt");
            Console.WriteLine($"{theBossBaby.FileName} has {theBossBaby.DistinctWordCountList.Count} words.");
            Console.WriteLine("===================================");

            var filePaths = Directory.GetFiles("SrtFiles", "*.srt");
            var data = _srtWordCountService.GetSrtStatisticsMultiFiles(filePaths);
            foreach (var item in data)
            {
                Console.WriteLine($"{item.FileName} has {item.DistinctWordCountList.Count} words.");
            }
            Console.WriteLine("===================================");

            var total = _srtWordCountService.GetDistinctWordsMultiFiles(filePaths);
            Console.WriteLine("Total words exsisting in all movies: {0}", total.Count());

            Console.WriteLine("===================================");
            var wordsAcross = _srtWordCountService.GetDistinctWordsExistAcrossMultiFiles(filePaths);
            Console.WriteLine("Total words exsisting across in all movies: {0}", wordsAcross.Count());

            Console.WriteLine("===================================");
            var word = "you";
            var result = _srtWordCountService.IsWordExistInMultiFiles(word, filePaths);
            if (result)
            {
                Console.WriteLine($"The word \"{word}\" exists.");
            }
            else
            {
                Console.WriteLine($"The word \"{word}\" does not exist.");
            }
        }
    }
}
