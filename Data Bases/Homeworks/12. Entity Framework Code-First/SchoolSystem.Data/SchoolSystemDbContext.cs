using SchoolSystem.Data.Migrations;
using SchoolSystem.Models;
using System.Data.Entity;

namespace SchoolSystem.Data
{
    public class SchoolSystemDbContext : DbContext
    {
        public SchoolSystemDbContext()
            :base("SchoolSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemDbContext, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(x => x.Id);
            modelBuilder.Entity<Course>().Property(x => x.Name)
                .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Material>().HasKey(x => x.Id);
            modelBuilder.Entity<Material>().Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
