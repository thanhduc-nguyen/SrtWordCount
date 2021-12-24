using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrtWordCount.Core;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System.Collections.Generic;

namespace SrtWordCount.WebApp.Pages.Statistics
{
    public class EditModel : PageModel
    {
        private readonly ISrtStatisticsData _srtStatisticsData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public SrtStatisticsModel SrtStatisticsModel { get; set; }
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
                SrtStatisticsModel = _srtStatisticsData.GetSrtStatisticsById(statisticsId.Value);
            }
            else
            {
                SrtStatisticsModel = new SrtStatisticsModel();
            }
            if (SrtStatisticsModel == null)
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

            if (SrtStatisticsModel.Id > 0)
            {
                _srtStatisticsData.Update(SrtStatisticsModel);
            }
            else
            {
                _srtStatisticsData.Add(SrtStatisticsModel);
            }
            _srtStatisticsData.Commit();
            TempData["Message"] = "Statistics saved!";

            return RedirectToPage("./Detail", new { statisticsId = SrtStatisticsModel.Id });
        }
    }
}
