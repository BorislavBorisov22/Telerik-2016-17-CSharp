namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Info.Contracts;
    using PackageManager.Repositories;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;
    using Fakes;
    using System.Linq;

    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var packageRepo = new PackageRepository(loggerStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Add(null));  
        }

        [Test]
        public void AddPackageToPackages_WhenPackageDoesNotExistInThePackagesCollection()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var packages = new List<IPackage>();

            var packageRepository = new FakePackageRepository(loggerStub.Object, packages);

            var packageToAdd = new Mock<IPackage>();

            // act
            packageRepository.Add(packageToAdd.Object);

            // assert
            Assert.AreSame(packageToAdd.Object, packageRepository.Packages.First());
        }

        [Test]
        public void CallLoggersLogMethodWithStringContainingSameVersion_WhenPackageWithSameVersionExists()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(It.Is<string>(y => y.Contains("same version is already installed"))));

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepository = new PackageRepository(loggerMock.Object, packages);

            var packageToAdd = new Mock<IPackage>();
            packageToAdd.Setup(x => x.Name).Returns(packageName);
            packageToAdd.Setup(x => x.CompareTo(It.IsAny<IPackage>()))
                .Returns(0);

            // act
            packageRepository.Add(packageToAdd.Object);

            // assert
            loggerMock.Verify(x => x.Log(It.Is<string>(y => y.Contains("same version is already installed"))), Times.Once);
        }

        [Test]
        public void CallUpdateMethod_WhenPassedPackageExistsWithLowerVersionVersion()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(It.Is<string>(y => y.Contains("same version is already installed"))));

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepository = new FakePackageRepository(loggerMock.Object, packages);

            var packageToAdd = new Mock<IPackage>();
            packageToAdd.Setup(x => x.Name).Returns(packageName);
            packageToAdd.Setup(x => x.CompareTo(It.IsAny<IPackage>()))
                .Returns(1);

            // act
            packageRepository.Add(packageToAdd.Object);

            // assert
            Assert.IsTrue(packageRepository.IsUpdateCalled);
        }

        [Test]
        public void CallLoggersLogeMethodWithStringContainingThereIsAPackageWithNewerVersion_WhenPassedPackageExistsWithHigherVersion()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(It.Is<string>(y => y.Contains("There is a package with newer version"))));

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);

            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepository = new PackageRepository(loggerMock.Object, packages);

            var packageToAdd = new Mock<IPackage>();
            packageToAdd.Setup(x => x.Name).Returns(packageName);
            packageToAdd.Setup(x => x.CompareTo(It.IsAny<IPackage>()))
                .Returns(-1);

            // act
            packageRepository.Add(packageToAdd.Object);

            // assert
            loggerMock.Verify(x => x.Log(It.Is<string>(y => y.Contains("There is a package with newer version"))), Times.Once);
        }
    }
}
