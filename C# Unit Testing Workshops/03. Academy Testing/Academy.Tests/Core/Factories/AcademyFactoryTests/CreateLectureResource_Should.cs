namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    using System;

    using NUnit.Framework;
    using Academy.Core.Factories;
    using Academy.Models.Utils.LectureResources;

    [TestFixture]
    public class CreateLectureResource_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedTypeIsInvalid()
        {
            // arrange
            string type = "invalidType";
            string name = "validName";
            string url = "validURLBrat";
            var factory = AcademyFactory.Instance;

            // act and assert
            Assert.Throws<ArgumentException>(
                () => factory.CreateLectureResource(type, name, url));
        }

        [Test]
        public void ReturnNewVideoResource_WhenPassedTypeIsVideoAndAllParametersAreValid()
        {
            // arrange
            string type = "video";
            string name = "validName";
            string url = "validURLBrat";
            var factory = AcademyFactory.Instance;

            // act
            var returnedObj = factory.CreateLectureResource(type, name, url);

            // assert
            Assert.IsInstanceOf<VideoResource>(returnedObj);
        }

        [Test]
        public void ReturnNewPresentationResource_WhenPassedTypeIsPresentationAndAllParametersAreValid()
        {
            // arrange
            string type = "presentation";
            string name = "validName";
            string url = "validURLBrat";
            var factory = AcademyFactory.Instance;

            // act
            var returnedObj = factory.CreateLectureResource(type, name, url);

            // assert
            Assert.IsInstanceOf<PresentationResource>(returnedObj);
        }

        [Test]
        public void ReturnNewDemoResource_WhenPassedTypeIsDemoAndAllParametersAreValid()
        {
            // arrange
            string type = "demo";
            string name = "validName";
            string url = "validURLBrat";
            var factory = AcademyFactory.Instance;

            // act
            var returnedObj = factory.CreateLectureResource(type, name, url);

            // assert
            Assert.IsInstanceOf<DemoResource>(returnedObj);
        }

        [Test]
        public void ReturnNewHomeworkResource_WhenPassedTypeIsHomworkAndAllParametersAreValid()
        {
            // arrange
            string type = "homework";
            string name = "validName";
            string url = "validURLBrat";
            var factory = AcademyFactory.Instance;

            // act
            var returnedObj = factory.CreateLectureResource(type, name, url);

            // assert
            Assert.IsInstanceOf<HomeworkResource>(returnedObj);
        }
    }
}
