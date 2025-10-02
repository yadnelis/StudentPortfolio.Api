using Microsoft.EntityFrameworkCore;
using StudentPortfolio.API.Models.Entities;

namespace StudentPortfolio.API.Infrastructure
{
    public class StudentPortfolioContext: DbContext
    {
        public DbSet<Acknowledgement> Acknowledgements { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AcknowledmentCompetition> AcknowledmentCompetitions { get; set; }
        public DbSet<AcknowledgementStudentOrganization> AcknowledgementStudentOrganizations { get; set; }

        public StudentPortfolioContext(DbContextOptions<StudentPortfolioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("portfolio");

            modelBuilder.Entity<Acknowledgement>()
                .HasOne(x => x.AcknowledmentCompetition)
                .WithOne(x => x.Acknowledgement);
        }
    }
}
