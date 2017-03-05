namespace StudentsAndCourses.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class StudentTest
    {

        private IStudent validStudent;

        [TestInitialize]
        public void MakeValidStudent()
        {
            this.validStudent = new Student("Vankata", 12000);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWheCreated()
        {
            var student = new Student("Ivan", 12000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenNameIsEmpty()
        {
            var student = new Student("", 15000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThorExceptionWhenNameIsNull()
        {
            var student = new Student(null, 15000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentShouldThorExceptionWhenUniqNumberOutOfRange()
        {
            var student = new Student("Petko", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenJoiningNullCourse()
        {
            var student = validStudent;
            ICourse courseToJoin = null;
            student.JoinCourse(courseToJoin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenLeavingNullCourse()
        {
            var student = validStudent;
            ICourse courseToLeave = null;
            student.LeaveCourse(courseToLeave);
        }

        [TestMethod]
        public void StudentShouldReturnCorrectUniqueNumber()
        {
            var student = new Student("Stamat", 15000);
            var expectedNumber = 15000;

            Assert.AreEqual(expectedNumber, student.UniqueNumber);
        }

        [TestMethod]
        public void StudentShouldReturnCorrectName()
        {
            string studentName = "Ivaylo";
            var student = new Student(studentName, 16780);

            Assert.AreEqual(studentName, student.Name);
        }

        [TestMethod]
        public void StudentShouldJoinCourseCorrectly()
        {
            var student = validStudent;
            ICourse courseToJoin = new Course("Math");
            student.JoinCourse(courseToJoin);
        }

        [TestMethod]
        public void StudentSouhldLeaveCourseCorrectly()
        {
            var student = validStudent;
            ICourse course = new Course("Math");
            student.JoinCourse(course);
            student.LeaveCourse(course);
        }
    }
}
