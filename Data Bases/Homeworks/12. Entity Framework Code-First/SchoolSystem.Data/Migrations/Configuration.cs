namespace SchoolSystem.Data.Migrations
{
    using SchoolSystem.Models;
    using System; 
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.SchoolSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolSystem.Data.SchoolSystemDbContext context)
        {
            this.SeedHomeworks(context);
            this.SeedStudents(context);
            this.SeedCourses(context);
        }

        private void SeedHomeworks(SchoolSystemDbContext context)
        {
            if (context.Homeworks.Any())
            {
                return;
            }

            context.Homeworks.AddOrUpdate(new Homework()
            {
                Content = "DI Patterns",
                TimeSent = DateTime.Now
            });

            context.Homeworks.AddOrUpdate(new Homework()
            {
                Content = "DI Refactorings",
                TimeSent = new DateTime(2017, 10, 10)
            });

            context.Homeworks.AddOrUpdate(new Homework()
            {
                Content = "DI Refactorings",
                TimeSent = new DateTime(2017, 10, 10)
            });
        }

        private void SeedStudents(SchoolSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.AddOrUpdate(new Student()
            {
                Name = "Ivan Ivanov",
                Number = 12345
            });

            context.Students.AddOrUpdate(new Student()
            {
                Name = "Petko Petkov",
                Number = 123456
            });
        }

        private void SeedCourses(SchoolSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            var course = new Course()
            {
                Description = "Learn all about programming",
                Name = "C#",
            };

            course.Students.Add(context.Students.FirstOrDefault());

        }

    }
}
