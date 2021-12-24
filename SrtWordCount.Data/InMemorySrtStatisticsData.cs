using SrtWordCount.Core;
using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.Data
{
    public class InMemorySrtStatisticsData : ISrtStatisticsData
    {
        List<SrtStatisticsModel> srtStatisticsList;

        public InMemorySrtStatisticsData()
        {
            srtStatisticsList = new List<SrtStatisticsModel>
            {
                new SrtStatisticsModel
                {
                    Id = 1,
                    MovieTitle = "The Boss Baby 2017",
                    Genre = MovieGenre.Children,
                    Words = "the,you,I",
                    DistinctWordCounts = "[{\"Key\":\"you\",\"Value\":200},{\"Key\":\"i\",\"Value\":100},{\"Key\":\"to\",\"Value\":100}]"
                },
                new SrtStatisticsModel
                {
                    Id = 2,
                    MovieTitle = "Hitch 2005",
                    Genre = MovieGenre.Drama,
                    Words = "the,she,he",
                    DistinctWordCounts = "[{\"Key\":\"the\",\"Value\":250},{\"Key\":\"she\",\"Value\":150},{\"Key\":\"he\",\"Value\":150}]"
                }
            };
        }

        public IEnumerable<SrtStatisticsModel> GetAllSrtStatisticsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return srtStatisticsList;
            }
            else
            {
                return srtStatisticsList.Where(x => x.MovieTitle.ToLower().Contains(name.ToLower()));
            }
        }

        public SrtStatisticsModel GetSrtStatisticsById(int id)
        {
            return srtStatisticsList.SingleOrDefault(x => x.Id == id);
        }

        public SrtStatisticsModel Add(SrtStatisticsModel newSrtStatistics)
        {
            srtStatisticsList.Add(newSrtStatistics);
            newSrtStatistics.Id = srtStatisticsList.Max(x => x.Id) + 1;

            return newSrtStatistics;
        }

        public SrtStatisticsModel Update(SrtStatisticsModel updatedSrtStatistics)
        {
            var statistics = srtStatisticsList.SingleOrDefault(x => x.Id == updatedSrtStatistics.Id);
            if (statistics != null)
            {
                statistics.MovieTitle = updatedSrtStatistics.MovieTitle;
                statistics.Genre = updatedSrtStatistics.Genre;
            }

            return statistics;
        }

        public SrtStatisticsModel Delete(int id)
        {
            var srtStatistics = srtStatisticsList.FirstOrDefault(x => x.Id == id);
            if (srtStatistics != null)
            {
                srtStatisticsList.Remove(srtStatistics);
            }

            return srtStatistics;
        }

        public int GetCountOfSrts()
        {
            return srtStatisticsList.Count;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
