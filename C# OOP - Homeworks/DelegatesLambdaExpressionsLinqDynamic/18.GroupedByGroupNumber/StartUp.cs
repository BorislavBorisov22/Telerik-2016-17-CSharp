namespace GroupedByGroupNumber
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var students = new[]
            {
              new { Name = "Asen", Group = 1},
                new { Name = "Penka", Group = 2},
                new { Name = "Ivan", Group = 2},
                new { Name = "Traicho", Group = 3},
                new { Name = "Snejinka", Group = 1},
                new { Name = "Stamat", Group = 1},
                new {Name = "Petko", Group = 2}

           };

            var groups = from st in students
                         group st by st.Group into g
                         orderby g.Key
                         select g;

            foreach (var group in groups)
            {
                Console.WriteLine("Students from group {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
          
        }
    }
}
