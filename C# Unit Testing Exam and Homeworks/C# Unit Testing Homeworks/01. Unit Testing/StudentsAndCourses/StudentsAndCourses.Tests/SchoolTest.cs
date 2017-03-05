namespace StudentsAndCourses.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolShouldBeCreatedCorrectly()
        {
            var school = new School("Simeon Veliki");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowArgumentNullExceptionWheNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        public void SchoolShouldReturnNameCorrectly()
        {
            string schoolName = "Simeon Veliki";
            var school = new School(schoolName);
            Assert.AreEqual(schoolName, school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowArgumentNullExceptionWhenAddingNullStudent()
        {
            var school = new School("51 SOU");
            school.AddStudent(null);
        }

        [TestMethod]
        public void SchoolShouldAddStudentCorrectly()
        {
            var school = new School("51 SOU");
            var studentToAdd = new Student("Ivancho", 16590);

            school.AddStudent(studentToAdd);
            Assert.AreEqual(studentToAdd, school.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowInvalidOPerationExceptionWhenAddingStudentsWithSameID()
        {
            var school = new School("Telerik Academy");
            var firstStudent = new Student("Ivancho", 12345);
            var secondStudent = new Student("Goshko", 12345);
            school.AddStudent(firstStudent);
            school.AddStudent(secondStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShoulThrowArgumentNullExceptionWhenRemovingNullStudent()
        {
            var school = new School("Telerik Academy");
            school.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolShouldThrowArgumentExceptionWhennRemovingNinExistingStudent()
        {
            var school = new School("Telerik Academy");
            var studentToRemove = new Student("Pesho", 12345);
            school.RemoveStudent(studentToRemove);
        }

        [TestMethod]
        public void SchoolShouldRemoveStudentCorrectly()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Pesho", 12345);
            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThronArgumentNullExceptionWheAddingNullCourse()
        {
            ICourse courseToAdd = null;
            var school = new School("Telerik Academy");
            school.AddCourse(courseToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowInvalidOperationExceptionWhennAddingExistiingCourse()
        {
            var school = new School("Daskaloto brat");
            var courseToAdd = new Course("Inforamtika brat");
            school.AddCourse(courseToAdd);
            school.AddCourse(courseToAdd);
        }

        [TestMethod]
        public void SchoolShouldAddCourseCorrectly()
        {
            var school = new School("Daskaloto brat");
            var courseToAdd = new Course("Inforamtika brat");
            school.AddCourse(courseToAdd);

            Assert.AreEqual(courseToAdd, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowArgumenNullExceptionWhenRemovingNullCourse()
        {
            var school = new School("TU Sofia");
            school.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowInvalidOperationExceptionWhenRemovigNonExistingCourse()
        {
            var school = new School("NBU");
            var courseToRemove = new Course("Math");
            school.RemoveCourse(courseToRemove);
        }

        [TestMethod]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            var school = new School("NBU");
            var course = new Course("Math");
            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(0, school.Courses.Count);
        }
    }
}
