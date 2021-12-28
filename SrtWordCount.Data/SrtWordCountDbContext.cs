using Microsoft.EntityFrameworkCore;
using SrtWordCount.Data.Models;

namespace SrtWordCount.Data
{
    public class SrtWordCountDbContext : DbContext
    {
        public SrtWordCountDbContext(DbContextOptions<SrtWordCountDbContext> options) : base(options)
        {
        }

        public DbSet<SrtStatisticsModel> SrtStatisticsModelList { get; set; }
    }
}
