using Microsoft.EntityFrameworkCore;
using Portifolio.Models;

namespace Portifolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person>? persons { get; set; }
        public DbSet<Project>? projects { get; set; }

        public DbSet<Technology>? technologies { get; set; }

        public DbSet<ProjectTechnology>? projectTechnologies{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            #region Many to Many - ProjectTechnology
            builder.Entity<ProjectTechnology>().HasKey(
                pt => new { pt.idProject, pt.idTechnology }
            );
            builder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.project)
                .WithMany(p => p.technologies)
                .HasForeignKey(pt => pt.idProject);

            builder.Entity<ProjectTechnology>()
                .HasOne(pa => pa.technology)
                .WithMany(t => t.projectsWithTechnology)
                .HasForeignKey(pt => pt.idTechnology);
            #endregion
        }

    }
}