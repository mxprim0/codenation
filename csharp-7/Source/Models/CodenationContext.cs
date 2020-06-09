using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}