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
                Words = model.Words.Split(",").ToList(),
                DistinctWordCounts = JsonSerializer.Deserialize<List<KeyValuePair<string, int>>>(model.DistinctWordCounts)
            };
        }

        public static SrtStatisticsModel ConvertToSrtStatisticsModel(this SrtStatisticsViewModel model)
        {
            return new SrtStatisticsModel
            {
                Id = model.Id,
                MovieTitle = model.MovieTitle,
                Genre = model.Genre,
                Words = string.Join(",", model.Words),
                DistinctWordCounts = JsonSerializer.Serialize(model.DistinctWordCounts)
            };
        }
    }
}
