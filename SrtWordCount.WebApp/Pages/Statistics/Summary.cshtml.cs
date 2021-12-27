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
        private readonly ISrtWordCountService _srtWordCountService;
        private readonly ISrtStatisticsData _srtStatisticsData;

        public IEnumerable<SrtStatisticsModel> SrtStatisticsModels { get; set; }
        public List<KeyValuePair<MovieGenre, int>> TotalWordsGroupByGenre { get; set; }

        public SummaryModel(ISrtWordCountService srtWordCountService, ISrtStatisticsData srtStatisticsData)
        {
            _srtWordCountService = srtWordCountService;
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
            SrtStatisticsModels = _srtStatisticsData.GetAllSrtStatisticsByName();

            TotalWordsGroupByGenre = new List<KeyValuePair<MovieGenre, int>>();
            foreach (var genre in Enum.GetValues<MovieGenre>())
            {
                TotalWordsGroupByGenre.Add(new KeyValuePair<MovieGenre, int>(genre,
                    _srtWordCountService.GetAllDistinctWordsByGenre(
                        SrtStatisticsModels.Select(x => x.ConvertToSrtStatistics()), genre).Count()));
            }
        }
    }
}
