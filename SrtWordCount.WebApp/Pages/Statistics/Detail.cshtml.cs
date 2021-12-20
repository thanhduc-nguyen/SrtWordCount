using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class DetailModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        [TempData]
        public string Message { get; set; }
        public SrtStatistics SrtStatistics { get; set; }

        public DetailModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public IActionResult OnGet(int statisticsId)
        {
            SrtStatistics = _srtStatisticsData.GetSrtStatisticsById(statisticsId);
            if (SrtStatistics == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
