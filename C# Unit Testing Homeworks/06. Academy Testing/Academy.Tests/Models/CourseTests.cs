   namespace Academy.Tests.Models
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework; 
    using System;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Constructor_WhenPassedValidParamteter_ShouldAssignPassedValuesCorreclty()
        {
            // arrange
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            // act 
            var course = new Course(name, lecturesPerWeek, startingDate,endingDate);

            // assert 
            Assert.AreSame(name, course.Name);
            Assert.AreEqual(lecturesPerWeek, course.LecturesPerWeek);
            Assert.AreEqual(startingDate, course.StartingDate);
            Assert.AreEqual(endingDate, course.EndingDate);
        }

        [Test]
        public void Constructor_WhenPassedParametersAreValid_ShouldInitializeCollections()
        {
            // arrange
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            // act 
            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsNotNull(course.Lectures);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("someveryveryverylonginvalidstringthatwillfailitwillsurelyfail")]
        public void Name_WhenAssignedInvalidName_ShouldThrowArgumentException(string invalidName)
        {
            // arrange
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);
            
            // act and assert
            Assert.Throws<ArgumentException>(() => course.Name = invalidName);
        }

        [Test]
        public void Name_WhenassignedValueIsValid_ShouldNotThrowException()
        {
            // arrange
            string validNameToAssign = "AnotherValidName";
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act
            Assert.DoesNotThrow(() => course.Name = validNameToAssign);
        }

        [Test]
        public void Name_WhenAssignedWithValidValud_ShouldAssingNewValudCorrectly()
        {
            // arrange
            string validNameToAssign = "AnotherValidName";
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act
            course.Name = validNameToAssign;

            // assert
            Assert.AreEqual(course.Name, validNameToAssign);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void LecturesPerWeek_WhenPassedValueIsInvalid_ShouldThrowArgumentException(int invalidLecturesCount)
        {
            // arrange
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act and assert
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = invalidLecturesCount);
        }

        [Test]
        public void LecturesPerWeek_WhenValidValueIsPassed_ShouldNotThrowException()
        {
            // arrange
            int lecturesPerWeekToAssign = 3;
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act and assert
            Assert.DoesNotThrow(() => course.LecturesPerWeek = lecturesPerWeekToAssign);

        }

        [Test]
        public void LecturesPerWeek_WhenValidValueIsPassed_ShouldAssignNewValueCorrectly()
        {
            // arrange
            int lecturesPerWeekToAssign = 3;
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act 
            course.LecturesPerWeek = lecturesPerWeekToAssign;

            // assert
            Assert.AreEqual(course.LecturesPerWeek, lecturesPerWeekToAssign);
        }

        [Test]
        public void StartingDate_WhenPassedValue_WhenPassedValueIsValid_ShouldNotThrow()
        {
            DateTime dateToAssing = new DateTime(2017, 2, 2);
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.DoesNotThrow(() => course.StartingDate = dateToAssing);
        }

        [Test]
        public void StartingDate_WhenPassedValueIsCorrect_ShouldAssignNewValueCorreclty()
        {
            DateTime dateToAssing = new DateTime(2017, 2, 2);
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act 
            course.StartingDate = dateToAssing;

            // assert
            Assert.AreEqual(course.StartingDate,dateToAssing);
        }

        [Test]
        public void EndingDate_WhenPassedValidValue_ShouldNotThrow()
        {
            DateTime dateToAssing = new DateTime(2017, 2, 2);
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // assert
            Assert.DoesNotThrow(() => course.EndingDate = dateToAssing);
        }

        [Test]
        public void EndingDate_WhenPassedValidValue_ShouldAssignNewValueCorreclty()
        {
            // arrange
            DateTime dateToAssing = new DateTime(2017, 2, 2);
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            // act 
            course.EndingDate = dateToAssing;

            // assert
            Assert.AreEqual(course.EndingDate, dateToAssing);
        }

        [Test]
        public void ToString_WhenLecturesArePresent_ShouldIterateThroughCollections()
        {
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString()).Verifiable();
            course.Lectures.Add(lectureMock.Object);

            // act 
            var returnedvalue = course.ToString();

            // assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ToString_WhenNoLecturesInCourse_ShouldReturnStringThatContainsNoLectures()
        {
            string name = "ValidName";
            int lecturesPerWeek = 5;
            DateTime startingDate = new DateTime(2017, 1, 1);
            DateTime endingDate = new DateTime(2017, 3, 3);

            var course = new Course(name, lecturesPerWeek, startingDate, endingDate);
            string expected = "no lectures";
            // act 
            var returnedValue = course.ToString();

            // assert
            StringAssert.Contains(expected, returnedValue);
        }
    }
}
