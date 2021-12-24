using Microsoft.EntityFrameworkCore;
using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SrtWordCount.Data
{
    public class SqlSrtStatisticsData : ISrtStatisticsData
    {
        private readonly SrtWordCountDbContext _db;

        public SqlSrtStatisticsData(SrtWordCountDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SrtStatisticsModel> GetAllSrtStatisticsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _db.SrtStatisticsModelList;
            }
            else
            {
                return _db.SrtStatisticsModelList.Where(x => x.MovieTitle.ToLower().Contains(name.ToLower()));
            }
        }

        public SrtStatisticsModel GetSrtStatisticsById(int id)
        {
            return _db.SrtStatisticsModelList.Find(id);
        }

        public SrtStatisticsModel Add(SrtStatisticsModel newSrtStatistics)
        {
            _db.Add(newSrtStatistics);

            return newSrtStatistics;
        }

        public SrtStatisticsModel Update(SrtStatisticsModel updatedSrtStatistics)
        {
            var statistics = _db.SrtStatisticsModelList.Attach(updatedSrtStatistics);
            statistics.State = EntityState.Modified;

            return updatedSrtStatistics;
        }

        public SrtStatisticsModel Delete(int id)
        {
            var srtStatistics = GetSrtStatisticsById(id);
            if (srtStatistics != null)
            {
                _db.SrtStatisticsModelList.Remove(srtStatistics);
            }

            return srtStatistics;
        }

        public int GetCountOfSrts()
        {
            return _db.SrtStatisticsModelList.Count();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
