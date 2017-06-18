using SchoolSystem.Data;
using SchoolSystem.Models;

using System.Linq;

namespace SchoolSystem.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SchoolSystemDbContext();

            var student = context.Students.FirstOrDefault();

            var courseToAdd = new Course()
            {
                Name = "C# Unit Testing",
                Description = "Learn all about unit testing in .NET"
            };

            student.Courses.Add(courseToAdd);

            context.SaveChanges();
        }
    }
}
