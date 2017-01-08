namespace GroupedByGroupNumberUsingExtensionMethods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var students = new[]
           {
              new { Name = "Asen", Group = "Informatics"},
                new { Name = "Penka", Group = "History"},
                new { Name = "Ivan", Group = "Informatics"},
                new { Name = "Traicho", Group = "Mathematics"},
                new { Name = "Snejinka", Group = "History"},
                new { Name = "Stamat", Group = "Mathematics"},
                new {Name = "Petko", Group = "Geography"}

           };

            // using linq query
            var groups = students.GroupBy(st => st.Group).OrderBy(s => s.Key).ToList();

            foreach (var group in groups)
            {
                Console.WriteLine("Students from {0} Group", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
