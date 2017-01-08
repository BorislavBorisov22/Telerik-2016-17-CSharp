namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Student> students = new List<Student>()
        {
                new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 15 },
                new Student { FirstName = "Angel", LastName = "Petrov", Age = 19 },
                new Student { FirstName = "Penka", LastName = "Todorova", Age = 13 },
                new Student { FirstName = "Asen", LastName = "Stamatov", Age = 25 },
                new Student { FirstName = "Stamat", LastName = "Asenov", Age = 12 },
                new Student { FirstName = "Petkan", LastName = "Petkov", Age = 16 },
                new Student { FirstName = "Stoqnka", LastName = "Veleva", Age = 10 },
                new Student { FirstName = "Bill", LastName = "Gates", Age = 18 },
                new Student { FirstName = "Vladislav", LastName = "Asenov", Age = 23 },
                new Student { FirstName = "Zoro", LastName = "Ivanov", Age = 18 },
                new Student { FirstName = "Asen", LastName = "Asenov", Age = 28 },
        };

        public static void Main()
        {
            // task 3
            FirstNameBeforeLast();

            // task 4
            AgeRange();

            // task 5
            OrderStudents();
        }

        public static void FirstNameBeforeLast()
        {
            var firstBeforeLast = students.Where(st => st.FirstName.CompareTo(st.LastName) < 0)
                .ToList();

            Console.WriteLine("03.Students whose first name is before their last name alphabetically");
            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }

        public static void AgeRange()
        {
            var between18And24 = students.Where(st => st.Age >= 18 && st.Age <= 24)
                .Select(st => new { FirstName = st.FirstName, LastName = st.LastName });
            Console.WriteLine("04.Students First And Last Name whose age is between 19 and 24");
            foreach (var student in between18And24)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }

        public static void OrderStudents()
        {
            var orderedStudents = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName)
                .ToList();

            Console.WriteLine("05.Ordered students alphabetically by first name and the by last name");

            foreach (var student in orderedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
