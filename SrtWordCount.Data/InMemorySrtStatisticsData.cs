using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.Data
{
    public class InMemorySrtStatisticsData : ISrtStatisticsData
    {
        List<SrtStatistics> srtStatisticsList;

        public InMemorySrtStatisticsData()
        {
            srtStatisticsList = new List<SrtStatistics>
            {
                new SrtStatistics
                {
                    Id = 1,
                    MovieName = "The Boss Baby 2017",
                    Genre = MovieGenre.Children,
                    Words = new List<string> { "the","you","I" },
                    DistinctWordCountList = new List<WordCount>
                    {
                        new WordCount { Word = "the", Count = 200 },
                        new WordCount { Word = "you", Count = 150 },
                        new WordCount { Word = "I", Count = 100 }
                    }
                },
                new SrtStatistics
                {
                    Id = 2,
                    MovieName = "Hitch 2005",
                    Genre = MovieGenre.Drama,
                    Words = new List<string> { "the","you","I" },
                    DistinctWordCountList = new List<WordCount>
                    {
                        new WordCount { Word = "the", Count = 222 },
                        new WordCount { Word = "she", Count = 150 },
                        new WordCount { Word = "he", Count = 120 }
                    }
                }
            };
        }

        public IEnumerable<SrtStatistics> GetAllSrtStatisticsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return srtStatisticsList;
            }
            else
            {
                return srtStatisticsList.Where(x => x.MovieName.ToLower().Contains(name.ToLower()));
            }
        }

        public SrtStatistics GetSrtStatisticsById(int id)
        {
            return srtStatisticsList.SingleOrDefault(x => x.Id == id);
        }

        public SrtStatistics Update(SrtStatistics updatedSrtStatistics)
        {
            var statistics = srtStatisticsList.SingleOrDefault(x => x.Id == updatedSrtStatistics.Id);
            if (statistics != null)
            {
                statistics.MovieName = updatedSrtStatistics.MovieName;
                statistics.Genre = updatedSrtStatistics.Genre;
            }

            return statistics;
        }

        public int Commit()
        {
            return 0;
        }

        public SrtStatistics Add(SrtStatistics newSrtStatistics)
        {
            srtStatisticsList.Add(newSrtStatistics);
            newSrtStatistics.Id = srtStatisticsList.Max(x => x.Id) + 1;
            return newSrtStatistics;
        }
    }
}
