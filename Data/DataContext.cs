using Microsoft.EntityFrameworkCore;
using Rest_API_final.Models;

namespace Rest_API_final.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentResult> ExperimentResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperimentResult>()
                .HasOne(er => er.Client)
                .WithMany(c => c.ExperimentResults)
                .HasForeignKey(er => er.ClientId);

            modelBuilder.Entity<ExperimentResult>()
                .HasOne(er => er.Experiment)
                .WithMany(c => c.ExperimentResults)
                .HasForeignKey(er => er.ExperimentId);
        }
    }
}
