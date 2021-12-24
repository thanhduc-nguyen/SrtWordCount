using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class ListModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public IEnumerable<SrtStatisticsViewModel> SrtStatisticsViewModelList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
            SrtStatisticsViewModelList = _srtStatisticsData.GetAllSrtStatisticsByName(SearchTerm)
                .Select(x => x.ConvertToSrtStatisticsViewModel());
        }
    }
}
