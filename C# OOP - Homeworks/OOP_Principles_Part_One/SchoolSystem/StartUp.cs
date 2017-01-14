namespace SchoolSystem
{
    using System;
    using SchoolSystem.Components;

    public static class StartUp
    {
        public static void Main()
        {
            TestSchoolSystem();
        }

        public static void TestSchoolSystem()
        {
            var firstClass = new Class("12B");
            firstClass.AddStudent(new Student("Ivan", 1));
            firstClass.AddStudent(new Student("Todor", 2));
            firstClass.AddStudent(new Student("Dragan", 3));
            firstClass.AddStudent(new Student("Penka", 4));
            firstClass.AddTeacher(new Teacher("Radev"));
            firstClass.AddTeacher(new Teacher("Ivan Ivanov", "Great teacher!"));
            var ivailoTeacher = new Teacher("Ivailo Ivanov");
            ivailoTeacher.AddDiscipline(new Discipline("Math", 2, 2));
            ivailoTeacher.AddDiscipline(new Discipline("Informatics", 5, 9));
            ivailoTeacher.AddDiscipline(new Discipline("Biology", 1, 1));
            firstClass.AddTeacher(ivailoTeacher);

            var secondClass = new Class("12A");

            secondClass.AddStudent(new Student("Pesho", 12));
            secondClass.AddStudent(new Student("Tosho", "Best student", 2));
            secondClass.AddStudent(new Student("Ivancho", "Poot student", 4));
            secondClass.AddTeacher(new Teacher("Petko"));
            secondClass.AddTeacher(new Teacher("Ivan", "Best teacher in uour school"));
            var school = new School("SOU Tsar Simeon Veliki");
            school.AddClass(firstClass);
            school.AddClass(secondClass);

            Console.WriteLine(school);
        }
    }
}
