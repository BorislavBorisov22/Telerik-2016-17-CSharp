namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov",3),
                new Student("Petko","Todorov",5),
                new Student("Petio","Angelov",12),
                new Student("David", "Beckham",9),
                new Student("Samuel","Peter",5),
                new Student("Atanas", "Petrov",4),
                new Student("Ivailo","Vulchev",11),
                new Student("Stamat","Stamatov",10),
                new Student("Rosen", "Petrov",4),
                new Student("Ivailo","Andonov",5),
            };

            // students ordered by their grade
            Console.WriteLine("Students ordered by their grade:");
            var orderedByGrades = students.OrderBy(st => st.Grade).ToList();

            foreach (var student in orderedByGrades)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("------------------------");
            var workers = new List<Worker>()
            {
                new Worker("Asen","Ivanov",240,8),
                new Worker("Ivailo","Zahariev",120,4),
                new Worker("Toni","Ivanov",400,10),
                new Worker("Mario","Maldenov",330,4),
                new Worker("Georgi","Ivanov",340,8),
                new Worker("Penka","Stoilova",220,8),
                new Worker("Stoyanka","Karamfilova",90,4),
                new Worker("Iveta","Georgieva",900,10),
                new Worker("Miroslav","Tsvetanov",20,4),
                new Worker("Katy","Perry",30000,6),
            };

            // workers ordered in descending order by the money they earn per hour
            Console.WriteLine("Workers ordered by the money they earn per hour:");
            var orderedByMoneyPerHour = workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
            orderedByMoneyPerHour.ForEach(w => Console.WriteLine(w));
            Console.WriteLine("-----------------------");

            // students and workers combined and ordered by first and last name
            Console.WriteLine("Students and workers ordered by first name and last name:");
            List<Human> studentsAndWorkers = new List<Human>();
            studentsAndWorkers.AddRange(students);
            studentsAndWorkers.AddRange(workers);

            studentsAndWorkers = studentsAndWorkers.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();

            foreach (var human in studentsAndWorkers)
            {
                Console.WriteLine("{0} {1}",human.FirstName,human.LastName);
            }
            
            
        }
    }
}
