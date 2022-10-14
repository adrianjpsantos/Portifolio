using Microsoft.EntityFrameworkCore;
using Portifolio.Models;

namespace Portifolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person>? Persons { get; set; }
        public DbSet<Project>? Projects { get; set; }

        public DbSet<Technology>? Technologies { get; set; }

        public DbSet<ProjectTechnology>? ProjectTechnologies{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            #region Many to Many - ProjectTechnology
            builder.Entity<ProjectTechnology>().HasKey(
                pt => new { pt.IdProject, pt.IdTechnology }
            );
            builder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.Technologies)
                .HasForeignKey(pt => pt.IdProject);

            builder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(t => t.ProjectsWithTechnology)
                .HasForeignKey(pt => pt.IdTechnology);
            #endregion
        }

    }
}