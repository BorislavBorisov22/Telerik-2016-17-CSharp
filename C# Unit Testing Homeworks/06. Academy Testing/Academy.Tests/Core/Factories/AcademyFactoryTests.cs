namespace Academy.Tests.Core.Factories
{
    using System;

    using NUnit.Framework;
    using Academy.Core.Factories;

    [TestFixture]
    public class AcademyFactoryTests
    {
        [TestCase("invalidtype")]
        [TestCase(null)]
        [TestCase("")]
        public void CreateLectureResource_WhenPassedInvalidType_ShouldThrowArgumentException(string type)
        {
            // arrange
            var factory = AcademyFactory.Instance;
            string name = "some name";
            string url = "someurl";

            // act and assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource(type, name, url));
        }

        [TestCase("video", "VideoResource")]
        [TestCase("presentation", "PresentationResource")]
        [TestCase("demo", "DemoResource")]
        [TestCase("homework", "HomeworkResource")]
        public void CreateLectureResource_WhenPassedValidTypeAndParamteres_ShouldReturnTheExpectedType(string type, string expectedType)
        {
            // arrange
            var factory = AcademyFactory.Instance;
            string name = "some name";
            string url = "someurl";

            // act
            var returnedValue = factory.CreateLectureResource(type, name, url);

            // assert
            Assert.AreEqual(expectedType, returnedValue.GetType().Name);
        }
    }
}
