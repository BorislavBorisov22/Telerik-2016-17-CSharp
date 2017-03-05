namespace Academy.Tests
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_WhenPesentUsersInCourse_ShouldCallUsersToString()
        {
            // arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            var studentMock = new Mock<IStudent>();
            var trainerMock = new Mock<ITrainer>();

            studentMock.Setup(x => x.ToString()).Verifiable();
            trainerMock.Setup(x => x.ToString()).Verifiable();

            season.Students.Add(studentMock.Object);
            season.Trainers.Add(trainerMock.Object);

            // act
            season.ListUsers();

            // assert
            studentMock.Verify();
            trainerMock.Verify();
        }

        [Test]
        public void ListUsers_WhenNoUsersPresentInSeason_ShouldReturnStringContainingNoUsers()
        {
            // arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);
            string expected = "no users";
            // act
            var returnValue = season.ListUsers();

            // assert
            StringAssert.Contains(expected, returnValue);
        }

        [Test]
        public void ListCourser_WhenPresentCoursesInSeason_ShouldCallCoursesToString()
        {
            // arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString()).Verifiable();

            season.Courses.Add(courseMock.Object);
            // act
            season.ListCourses();

            // assert
            courseMock.Verify();
        }

        [Test]
        public void ListCourser_WhenNoCoursesInSeason_ShoudlReturnStringThatContainsNoCourses()
        {
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            string expected = "no courses";
            // act
             var returnedValue = season.ListCourses();

            // assert
            StringAssert.Contains(expected, returnedValue);
        }
    }
}
