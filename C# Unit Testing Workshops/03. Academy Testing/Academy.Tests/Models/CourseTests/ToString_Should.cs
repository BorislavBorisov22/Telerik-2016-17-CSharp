namespace Academy.Tests.Models.CourseTests
{
    using System;

    using NUnit.Framework;
    using Academy.Models;
    using Moq;
    using Academy.Models.Contracts;

    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void CallAllLecturesInCollectionToStringMethod_WhenCalled()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString());
            course.Lectures.Add(lectureMock.Object);

            // act
            course.ToString();

            // assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ReturnStringContainingNoLectures_WhenCalledWithNoCurrentLecturesInCourse()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            string expectedResult = "no lectures";

            // act
            string result = course.ToString();

            // assert
            StringAssert.Contains(expectedResult, result);
        }
    }
}
