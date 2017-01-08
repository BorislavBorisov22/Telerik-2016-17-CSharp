namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(
                "Ivailo",
                "Zahariev",
                "111406",
                "094647311",
                "ivailo.zahariev@abv.bg",
                new List<int>() {5,5,5,5,5,5,5,5,4 },
                1,
                 new Group (1, "Geology")
                ),
            new Student(
                "Rosen",
                "Gatsov",
                "123406",
                "02983652",
                "kukata@abv.bg",
                new List<int>(){6, 6, 6, 6, 6, 6, 6, 6 },
                2,
                 new Group (2, "Mathematics")
                ),

            new Student(
                "Ivo",
                "Andonov",
                "489206",
                "02591306",
                "boss-mafia@abv.bg",
                new List<int>() { 2,3,4,5,5,5},
                1,
                 new Group (1, "Mathematics")
                ),
            new Student(
                "Valdes",
                "Vladimirov",
                "111803",
                "0856901243",
                "i-lovec-sum-i-ribar-sum@yahoo.com",
                new List<int>() {4,3,5,5,5 },
                1,
                 new Group (1, "Biology")
                ),
            new Student(
                "Alexander",
                "Alexandrov",
                "234561",
                "02451722",
                "sasheto@gmail.com",
                new List<int>() {2,2,2,5,4,3,3,6 },
                2,
                 new Group (2, "Mathematics")
                ),
            new Student(
                "Penka",
                "Izdislav",
                "045329",
                "05856910",
                "penka_izdislav@abv.bg",
                new List<int>() {5,6 },
                1,
                new Group (1, "Informatics")
                ),
        };

        public static void Main()
        {
            // task 9
            GetStudentsFromSecondGroup_Linq();

            // task 10
            GetStudentsFromSecondGroup_ExtensionMethods();

            // task 11
            GetStudentsFromABV();

            // task 12
            GetStudentsWithSofiaPhones();

            // task 13
            ExtractStudentsByMarks();

            // task 14
            ExtractStudentsWithTwoMarks();

            // task 15
            ExtractMarks();

            // task 16
            GetMathematics();
        }

        public static void PrintStudents(IEnumerable<Student> studentsCollection)
        {
            foreach (var student in studentsCollection)
            {
                Console.WriteLine(student);
                Console.WriteLine("----------");
            }
        }

        public static void GetStudentsFromSecondGroup_Linq()
        {
            var targetStudents = from st in students
                                 where st.GroupNumber == 2
                                 select st;
            Console.WriteLine("Extracted Students that have Group number = 2 (using Linq)");
            PrintStudents(targetStudents);
            Console.WriteLine();
        }

        public static void GetStudentsFromSecondGroup_ExtensionMethods()
        {
            var targetStudents = students.Where(st => st.GroupNumber == 2).ToList();
            Console.WriteLine("Extracted Students that have Group number two using extension methods");
            PrintStudents(targetStudents);
            Console.WriteLine();
        }

        public static void GetStudentsFromABV()
        {
            var targetStudents = from st in students
                                 where st.Email.EndsWith("abv.bg")
                                 select st;
            Console.WriteLine("Students that have \"abv.bg\" emails:");
            PrintStudents(targetStudents);
            Console.WriteLine();
        }

        public static void GetStudentsWithSofiaPhones()
        {
            var targetStudents = from st in students
                                 where st.Tel.StartsWith("02")
                                 select st;
            Console.WriteLine("Students that have phone numbers in Sofia:");
            PrintStudents(targetStudents);
            Console.WriteLine();
        }

        public static void ExtractStudentsByMarks()
        {
            var targetStudents = from st in students
                                 where st.Marks.Contains(6)
                                 select new
                                 {
                                     FullName = st.FirstName + " " + st.LastName,
                                     Marks = string.Join(", ", st.Marks)
                                 };
            Console.WriteLine("Students that have at least one excellent mark");
            foreach (var student in targetStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }

        public static void ExtractStudentsWithTwoMarks()
        {
            var targetStudents = students.Where(st => st.Marks.Count == 2).ToList();

            Console.WriteLine("Students that have exactly two marks:");
            PrintStudents(targetStudents);
            Console.WriteLine();
        }

        public static void ExtractMarks()
        {
            var targetMarks = students.Where(st => st.FacultyNumber.EndsWith("06"))
                .SelectMany(st => st.Marks.Select(m => m));
            Console.WriteLine("Marks of students that enrolled in 2006:");
            Console.WriteLine(string.Join(", ", targetMarks));
            Console.WriteLine();
        }

        public static void GetMathematics()
        {
            var studentsFromMathDepartment = students
                .Where(st => st.Group.DepartmentName.Equals("Mathematics"))
                .Select(st => new
                {
                    FullName = st.FirstName + " " + st.LastName,
                    GroupNumber = st.Group.GroupNumber,
                    Department = st.Group.DepartmentName
                });

            Console.WriteLine("Students from the mathematics department:");

            foreach (var student in studentsFromMathDepartment)
            {
                Console.WriteLine(student);
            }
        }
    }
}
