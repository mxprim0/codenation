using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey(c => new { c.UserId, c.AccelerationId, c.CompanyId });
            modelBuilder.Entity<Submission>().HasKey(s => new { s.UserId, s.ChallengeId });
            modelBuilder.Entity<Acceleration>().Property(a => a.Name).HasMaxLength(100);
            modelBuilder.Entity<Acceleration>().Property(a => a.Slug).HasMaxLength(50);
            modelBuilder.Entity<Company>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(c => c.Slug).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Nickname).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(255);
            modelBuilder.Entity<Challenge>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Challenge>().Property(c => c.Slug).HasMaxLength(50);
        }
    }
}