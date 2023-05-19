using Microsoft.EntityFrameworkCore;
using RestApi_test.Models;

namespace RestApi_test.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentResult> ExperimentResults { get; set; }
     

        public async Task<List<ExperimentResult>> GetExperimentResultsAsync()
        {
            return await ExperimentResults.ToListAsync();
        }
    }
}
