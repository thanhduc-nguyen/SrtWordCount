using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SrtWordCount.Core;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SrtWordCount.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISrtWordCountService _srtWordCountService;
        private readonly ISrtStatisticsData _srtStatisticsData;

        [Required(ErrorMessage = "Cannot upload files.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".srt")]
        [Display(Name = "Select files to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISrtWordCountService srtWordCountService, ISrtStatisticsData srtStatisticsData)
        {
            _logger = logger;
            _srtWordCountService = srtWordCountService;
            _srtStatisticsData = srtStatisticsData;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (FileUploads.Length > 0)
            {
                foreach (var file in FileUploads)
                {
                    var result = new StringBuilder();
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {
                        while (reader.Peek() >= 0)
                        {
                            result.AppendLine(reader.ReadLine());
                        }
                    }

                    string text = result.ToString();
                    var srtStatistics = _srtWordCountService.AnalyzeSrtStatistics(file.FileName, text);
                    var srtStatisticsModel = new SrtStatisticsModel
                    {
                        Id = 0,
                        MovieTitle = srtStatistics.MovieTitle,
                        Genre = srtStatistics.Genre,
                        Year = srtStatistics.Year,
                        Words = string.Join<string>(",", srtStatistics.Words),
                        DistinctWordCounts = JsonSerializer.Serialize(srtStatistics.DistinctWordCounts),
                        TotalWords = srtStatistics.Words.Count,
                        TotalDistictWordCounts = srtStatistics.DistinctWordCounts.Count
                    };
                    _srtStatisticsData.Add(srtStatisticsModel);
                    _srtStatisticsData.Commit();
                }

                return RedirectToPage("./Statistics/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
