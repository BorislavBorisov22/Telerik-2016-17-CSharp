namespace Students
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            TestStudentClass();
        }

        public static void TestStudentClass()
        {
            var ivanStudent = new Student(
                "Ivan",
                "Ivanov", 
                "Ivanov",
                "111215439",
                "Tsar Ivan Asen II - Sofia",
                "0899456782", 
                "vankata_seksipich",
                3,
                Specialty.AppliedMathematics,
                University.TechnicalUniversity, 
                Faculty.Mathematics);

            var ivailoStudent = new Student(
                "Ivailo", 
                "Petrov", 
                "Ivanov",
                "111215114",
                "Shiroka - Sofia",
                "093651104", 
                "ivo.andonov33",
                3,
                Specialty.DentalMedicine,
                University.Harvard, 
                Faculty.Medicine);

            // printing ivan information to check the ToString() method implementation
            Console.WriteLine(ivanStudent);
            Console.WriteLine("==================");

            // getting ivailoStudent hashCode to chek the GetHashCode() method implementation
            Console.WriteLine("ivailoStudent hashcode: {0}", ivailoStudent.GetHashCode());

            // checkinng the == and != operators by comapring the two students
            Console.WriteLine("Are students equal: {0}", ivailoStudent == ivanStudent);

            // Console.WriteLine("Are students equal: {0}", ivailoStudent == (Student)ivailoStudent.Clone());
            Console.WriteLine("Are students not equal: {0}", ivailoStudent != ivanStudent);

            // testing the CompareTo method implementation
            Console.WriteLine("CompareTo() result: {0}", ivailoStudent.CompareTo(ivanStudent));
            Console.WriteLine("============");

            // testing the clone method
            var cloneIvan = (Student)ivanStudent.Clone();
            Console.WriteLine("Cloned student info:");
            Console.WriteLine(cloneIvan);

            Console.WriteLine("ivanStudent and clone object of ivanStudent have the same refference: {0}", ReferenceEquals(ivanStudent, cloneIvan));
            Console.WriteLine(ReferenceEquals(ivanStudent, ivanStudent));
        }
    }
}
