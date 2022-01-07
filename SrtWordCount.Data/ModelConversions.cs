using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace SrtWordCount.Data
{
    public static class ModelConversions
    {
        public static SrtStatisticsViewModel ConvertToSrtStatisticsViewModel(this SrtStatisticsModel model)
        {
            return new SrtStatisticsViewModel
            {
                Id = model.Id,
                MovieTitle = model.MovieTitle,
                Genre = model.Genre,
                Year = model.Year,
                Words = model.Words.Split(",").ToList(),
                DistinctWordCounts = JsonSerializer.Deserialize<List<KeyValuePair<string, int>>>(model.DistinctWordCounts),
                TotalWords = model.TotalWords,
                TotalDistictWordCounts = model.TotalDistictWordCounts
            };
        }
    }
}
