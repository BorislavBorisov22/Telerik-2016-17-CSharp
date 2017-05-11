namespace Academy.Tests.Models.CourseTests
{
    using System;

    using NUnit.Framework;
    using Academy.Models;

    [TestFixture]
    public class Name_Should
    {
        [TestCase(null)]
        [TestCase("ii")]
        [TestCase("very long long very long longvery long longvery long longvery long longvery long longvery long long")]
        public void ThrowArgumentException_WhenPassedValueIsInvalid(string invalidName)
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();
            
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act and assert
            Assert.Throws<ArgumentException>(() => course.Name = invalidName);
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
            string newValidName = "otherValidName";

            // act and assert
            Assert.DoesNotThrow(() => course.Name = newValidName);
        }

        [Test]
        public void CorrectlyAssignPassedValue_WhenValidValueIsPassed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);
            string newValidName = "otherValidName";

            // act
            course.Name = newValidName;

            // assert
            Assert.AreEqual(newValidName, course.Name);
        }
    }
}
