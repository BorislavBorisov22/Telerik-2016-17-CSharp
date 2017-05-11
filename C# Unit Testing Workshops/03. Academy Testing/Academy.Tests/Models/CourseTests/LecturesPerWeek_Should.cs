namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LecturesPerWeek_Should
    {
        [TestCase(0)]
        [TestCase(8)]
        public void ThrowArgumentException_WhenPassedValueIsInvalid(int newLectures)
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act and assert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = newLectures);
        }

        [Test]
        public void NotThrow_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            int newValidLectures = 7;

            // act and assert
            Assert.DoesNotThrow(() => course.LecturesPerWeek = newValidLectures);
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

            int newValidLectures = 7;

            // act
            course.LecturesPerWeek = newValidLectures;

            // assert
            Assert.AreEqual(newValidLectures, course.LecturesPerWeek);
        }
    }
}
