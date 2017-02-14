namespace StudentsAndCourses.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseShouldBeCreatedCorrectly()
        {
            var course = new Course("Mathematics");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumentNullExceptionWhenNameIsEmpty()
        {
            var course = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumentNullExceptionWheNameIsNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void CourseShouldReturnNameCorrectly()
        {
            var course = new Course("Mathematics");
            var expected = "Mathematics";
            Assert.AreEqual(expected, course.Name);
        }

        [TestMethod]
        public void CourseStudentsCountShouldBeZeroWhenCourseCreated()
        {
            var course = new Course("Biology");
            int expectedStudentsInCourse = 0;
            Assert.AreEqual(expectedStudentsInCourse, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumenNullExceptionWhenAddingNullStudent()
        {
            var course = new Course("History");
            IStudent studentToAdd = null;
            course.AddStudent(studentToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowInvalidOperationExWhenAddingExistingStudent()
        {
            var course = new Course("Unit testing");
            var petranchoStudent = new Student("Petrancho", 16983);
            course.AddStudent(petranchoStudent);
            course.AddStudent(petranchoStudent);
        }

        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("Math");
            var studentToAdd = new Student("Ivancho", 15000);
            course.AddStudent(studentToAdd);
            int expectedStudentsInCourse = 1;

            Assert.AreEqual(expectedStudentsInCourse, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumentNullExceptionWhenRemovingNullStudent()
        {
            var course = new Course("JavaScript OOP");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseSHouldThrowArgumentExceptionWhenRemoveingNonExistingStudent()
        {
            var course = new Course("C# OOP");
            var studentToRemove = new Student("Dragomir", 12450);
            course.RemoveStudent(studentToRemove);
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("JavaScript UI and DOM");
            var student = new Student("Teodor", 14300);
            course.AddStudent(student);
            course.RemoveStudent(student);
            int expectedStudentsCount = 0;

            Assert.AreEqual(expectedStudentsCount, course.Students.Count);
        }
    }
}
