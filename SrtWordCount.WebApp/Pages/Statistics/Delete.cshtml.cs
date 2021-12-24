using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class DeleteModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public SrtStatisticsViewModel SrtStatisticsViewModel;

        public DeleteModel(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public IActionResult OnGet(int statisticsId)
        {
            var srtStatisticsModel = _srtStatisticsData.GetSrtStatisticsById(statisticsId);

            SrtStatisticsViewModel = srtStatisticsModel.ConvertToSrtStatisticsViewModel();
            if (srtStatisticsModel == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int statisticsId)
        {
            var srtStatistics = _srtStatisticsData.Delete(statisticsId);
            _srtStatisticsData.Commit();

            if (srtStatistics == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{srtStatistics.MovieTitle} deleted.";

            return RedirectToPage("./List");
        }
    }
}
