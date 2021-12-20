using System.Collections.Generic;

namespace SrtWordCount.Data
{
    public interface ISrtStatisticsData
    {
        IEnumerable<SrtStatistics> GetAllSrtStatisticsByName(string name);
        SrtStatistics GetSrtStatisticsById(int id);
        SrtStatistics Update(SrtStatistics updatedSrtStatistics);
        SrtStatistics Add(SrtStatistics newSrtStatistics);
        int Commit();
    }
}
