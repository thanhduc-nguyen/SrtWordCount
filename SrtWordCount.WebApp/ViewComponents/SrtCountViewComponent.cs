using Microsoft.AspNetCore.Mvc;
using SrtWordCount.Data;

namespace SrtWordCount.WebApp.ViewComponents
{
    public class SrtCountViewComponent : ViewComponent
    {
        private readonly ISrtStatisticsData _srtStatisticsData;

        public SrtCountViewComponent(ISrtStatisticsData srtStatisticsData)
        {
            _srtStatisticsData = srtStatisticsData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _srtStatisticsData.GetCountOfSrts();
            return View(count);
        }
    }
}
