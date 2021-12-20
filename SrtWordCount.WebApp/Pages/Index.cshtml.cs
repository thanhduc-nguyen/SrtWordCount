using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SrtWordCount.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISrtWordCountService _srtWordCountService;

        [Required(ErrorMessage = "Cannot upload files.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "srt")]
        [Display(Name = "Select files to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISrtWordCountService srtWordCountService)
        {
            _logger = logger;
            _srtWordCountService = srtWordCountService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
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
                }
            }
        }
    }
}
