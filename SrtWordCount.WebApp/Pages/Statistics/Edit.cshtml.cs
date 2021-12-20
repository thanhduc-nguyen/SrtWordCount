using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrtWordCount.Data;
using System.Collections.Generic;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class EditModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public SrtStatistics SrtStatistics { get; set; }
        public IEnumerable<SelectListItem> MovieGenres { get; set; }

        public EditModel(ISrtStatisticsData srtStatisticsData, IHtmlHelper htmlHelper)
        {
            _srtStatisticsData = srtStatisticsData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? statisticsId)
        {
            MovieGenres = _htmlHelper.GetEnumSelectList<MovieGenre>();
            if (statisticsId.HasValue)
            {
                SrtStatistics = _srtStatisticsData.GetSrtStatisticsById(statisticsId.Value);
            }
            else
            {
                SrtStatistics = new SrtStatistics();
            }
            if (SrtStatistics == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                MovieGenres = _htmlHelper.GetEnumSelectList<MovieGenre>();
                return Page();
            }

            if (SrtStatistics.Id > 0)
            {
                _srtStatisticsData.Update(SrtStatistics);
            }
            else
            {
                _srtStatisticsData.Add(SrtStatistics);
            }
            _srtStatisticsData.Commit();
            TempData["Message"] = "Statistics saved!";

            return RedirectToPage("./Detail", new { statisticsId = SrtStatistics.Id });
        }
    }
}
