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

       
    }
}
