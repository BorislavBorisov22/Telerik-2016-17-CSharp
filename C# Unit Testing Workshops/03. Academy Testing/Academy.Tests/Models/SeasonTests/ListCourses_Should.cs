using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.SeasonTests
{
    [TestFixture]
    public class ListCourses_Should
    {
        [Test]
        public void ReturnStringContainingNoCourses_WhenNoUsersArePresentInCollections()
        {
            // arrange
            int starting = 2016;
            int ending = 2017;
            var initiative = Initiative.SoftwareAcademy;

            var season = new Season(starting, ending, initiative);

            string expectedResult = "no courses";

            // act
            var result = season.ListCourses();

            // assert
            StringAssert.Contains(expectedResult, result);
        }

        [Test]
        public void CallAllCoursesInCoursesCollectionToStringMethod_WhenCalled()
        {
            // arrange
            int starting = 2016;
            int ending = 2017;
            var initiative = Initiative.SoftwareAcademy;

            var season = new Season(starting, ending, initiative);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString());

            season.Courses.Add(courseMock.Object);

            // act
            season.ListCourses();

            // assert
            courseMock.Verify(x => x.ToString(), Times.Once);
        }
    }
}
