using Academy.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class CourseConstructor_Should
    {
        [Test]
        public void CorrectlyAssignNameValue_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.AreEqual(name, course.Name);
        }

        [Test]
        public void CorrectlyAssignLecturesPerWeekValue_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.AreEqual(lecturesPerWeek, course.LecturesPerWeek);
        }

        [Test]
        public void CorrectlyAssignStartingDate_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.AreEqual(startingDate, course.StartingDate);
        }


        [Test]
        public void CorrectlyAssignEndingDate_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.AreEqual(endingDate, course.EndingDate);
        }

        [Test]
        public void CorrectlyInitiateOnlineStudentsCollection_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.IsNotNull(course.OnlineStudents);
        }

        [Test]
        public void CorrectlyInitiateOnsiteStudentsCollection_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.IsNotNull(course.OnsiteStudents);
        }

        [Test]
        public void CorrectlyInitiateLecturesCollection_WhenObjectIsConstructed()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime();
            DateTime endingDate = new DateTime();

            // act
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.IsNotNull(course.Lectures);
        }
    }
}
