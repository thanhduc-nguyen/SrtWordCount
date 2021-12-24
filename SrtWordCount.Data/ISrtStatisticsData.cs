using SrtWordCount.Data.Models;
using System.Collections.Generic;

namespace SrtWordCount.Data
{
    public interface ISrtStatisticsData
    {
        IEnumerable<SrtStatisticsModel> GetAllSrtStatisticsByName(string name);
        SrtStatisticsModel GetSrtStatisticsById(int id);
        SrtStatisticsModel Add(SrtStatisticsModel newSrtStatistics);
        SrtStatisticsModel Update(SrtStatisticsModel updatedSrtStatistics);
        SrtStatisticsModel Delete(int id);
        int GetCountOfSrts();
        int Commit();
    }
}
