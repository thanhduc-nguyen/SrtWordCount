using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;
using System.Collections.Generic;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class ListModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public IEnumerable<SrtStatistics> SrtStatisticsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
            SrtStatisticsList = _srtStatisticsData.GetAllSrtStatisticsByName(SearchTerm);
        }
    }
}
