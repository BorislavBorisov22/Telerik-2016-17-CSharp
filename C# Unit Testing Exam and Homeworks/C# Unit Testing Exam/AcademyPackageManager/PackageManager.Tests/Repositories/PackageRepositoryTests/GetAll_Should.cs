namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using PackageManager.Repositories.Contracts;
    using PackageManager.Repositories;
    using Info.Contracts;
    using System.Collections;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnEmptyCollection_WhenNoPackagesArePresentInCollection()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();

            var packageRepository = new PackageRepository(loggerStub.Object, packages);

            // act
            var returnedCollection = packageRepository.GetAll();

            // assert
            Assert.AreEqual(0, packages.Count);
        }

        [Test]
        public void ReturnCollectionWithAllPackagesInRepository_WhenPackagesCollectionHasPackagesInIt()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();
            var packageStub = new Mock<IPackage>();
            var packages = new List<IPackage>()
            {
                packageStub.Object,
                packageStub.Object
            };

            var packageRepository = new PackageRepository(loggerStub.Object, packages);

            // act
            var returnedCollection = packageRepository.GetAll();

            // assert
            Assert.AreEqual(2, packages.Count);
        }
    }
}
