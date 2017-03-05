namespace PackageManager.Tests.Models.ProjectTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models;
    using Repositories;
    using Moq;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using PackageManager.Repositories.Contracts;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetNameCorrectly_WhenAllPasedValuesAreValid()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";

            // act
            var project = new Project(name, location);

            // assert
            Assert.AreEqual(name, project.Name);
        }

        [Test]
        public void SetLocationCorrectly_WhenAllPasedValuesAreValid()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";

            // act
            var project = new Project(name, location);

            // assert
            Assert.AreEqual(location, project.Location);
        }

        [Test]
        public void SetPackageRepositoryToNewPackageRepository_WhenNoParameterIsProvidedForItAndTheOptionalParameterIsCalled()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";

            // act
            var project = new Project(name, location);

            // assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void SetPackageRepositoryToTheProvidedOne_WhenPassedPackageRepositoryIsValid()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";
            var packageRepositoryStub = new Mock<IRepository<IPackage>>();

            // act
            var project = new Project(name, location, packageRepositoryStub.Object);

            // assert
            Assert.AreSame(project.PackageRepository, packageRepositoryStub.Object);
        }
    }
}
