using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class DetailModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        [TempData]
        public string Message { get; set; }
        public SrtStatisticsViewModel SrtStatisticsViewModel { get; set; }

        public DetailModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public IActionResult OnGet(int statisticsId)
        {
            var model = _srtStatisticsData.GetSrtStatisticsById(statisticsId);
            SrtStatisticsViewModel = model.ConvertToSrtStatisticsViewModel();
            if (SrtStatisticsViewModel == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
