using SrtWordCount.Core;
using System.Collections.Generic;

namespace SrtWordCount.Data.Models
{
    public class SrtStatisticsViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public MovieGenre Genre { get; set; }
        public List<string> Words { get; set; }
        public List<KeyValuePair<string, int>> DistinctWordCounts { get; set; }
        public int TotalWords { get; set; }
        public int TotalDistictWordCounts { get; set; }
    }
}
