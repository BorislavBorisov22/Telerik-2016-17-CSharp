namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class EndingDate_Should
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

            DateTime newValidDate = new DateTime(2017, 10, 10);

            // act and assert
            Assert.DoesNotThrow(() => course.EndingDate = newValidDate);
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
            course.EndingDate = newValidDate;

            // act and assert
            Assert.AreEqual(course.EndingDate, newValidDate);
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
            Assert.Throws<ArgumentNullException>(() => course.EndingDate = null);
        }
    }
}
