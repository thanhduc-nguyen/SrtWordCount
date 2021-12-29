using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.WebApp.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public IEnumerable<SrtStatisticsViewModel> SrtStatisticsViewModels { get; set; }
        public SrtStatisticsViewModel LeastWordSrt { get; set; }
        public SrtStatisticsViewModel MostWordSrt { get; set; }

        public SummaryModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
            SrtStatisticsViewModels = _srtStatisticsData.GetAllSrtStatisticsByName()
                .Select(x => x.ConvertToSrtStatisticsViewModel());

            if (SrtStatisticsViewModels.Any())
            {
                int min = SrtStatisticsViewModels.Min(x => x.TotalDistictWordCounts);
                LeastWordSrt = SrtStatisticsViewModels.Where(x => x.TotalDistictWordCounts == min).SingleOrDefault();

                int max = SrtStatisticsViewModels.Max(x => x.TotalDistictWordCounts);
                MostWordSrt = SrtStatisticsViewModels.Where(x => x.TotalDistictWordCounts == max).SingleOrDefault();
            }
        }
    }
}
