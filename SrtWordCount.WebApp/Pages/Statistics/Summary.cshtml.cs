using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Core;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.WebApp.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public IEnumerable<SrtStatisticsViewModel> SrtStatisticsViewModels { get; set; }
        public List<KeyValuePair<MovieGenre, int>> TotalWordsGroupByGenre { get; set; }

        public SummaryModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
            SrtStatisticsViewModels = _srtStatisticsData.GetAllSrtStatisticsByName(string.Empty)
                .Select(x => x.ConvertToSrtStatisticsViewModel());

            TotalWordsGroupByGenre = new List<KeyValuePair<MovieGenre, int>>();
            foreach (var genre in Enum.GetValues<MovieGenre>())
            {
                TotalWordsGroupByGenre.Add(new KeyValuePair<MovieGenre, int>(genre, GetAllDistinctWordsByGenre(genre).Count()));
            }
        }

        private IEnumerable<KeyValuePair<string, int>> GetAllDistinctWordsByGenre(MovieGenre genre)
        {
            var data1 = SrtStatisticsViewModels.Where(x => x.Genre == genre).Select(x => x.Words);
            var data2 = new List<string>();
            var result = new List<KeyValuePair<string, int>>();
            foreach (var item in data1)
            {
                data2.AddRange(item);
            }
            foreach (var line in data2.GroupBy(info => info)
                           .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()))
                           .OrderByDescending(x => x.Value))
            {
                result.Add(line);
            }
            return result;
        }
    }
}
