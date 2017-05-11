namespace Academy.Tests.Models.CourseTests
{
    using System;

    using NUnit.Framework;
    using Academy.Models;

    [TestFixture]
    public class StartingDate_Should
    {
        [Test]
        public void NotThrow_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            DateTime newValidDate = new DateTime(2017,10,10);

            // act and assert
            Assert.DoesNotThrow(() => course.StartingDate = newValidDate);
        }

        [Test]
        public void CorrectlyAssignNewValue_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            DateTime newValidDate = new DateTime(2017, 10, 10);

            // act
            course.StartingDate = newValidDate;

            // act and assert
            Assert.AreEqual(course.StartingDate,newValidDate);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedValueIsNull()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            DateTime newValidDate = new DateTime(2017, 10, 10);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate = null);
        }
    }
}
