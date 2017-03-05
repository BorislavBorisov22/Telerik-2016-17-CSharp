namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using Info.Contracts;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var packageRepositroy = new PackageRepository(loggerStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepositroy.Update(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageCannotBeFound()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var packages = new List<IPackage>();

            var packageRepositroy = new PackageRepository(loggerStub.Object, packages);

            var packageToUpdate = new Mock<IPackage>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepositroy.Update(packageToUpdate.Object));
        }

        [Test]
        public void ReturnTrue_WhenPackageIsFoundAndHasLowerVersionThanPassedPackage()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepositroy = new PackageRepository(loggerStub.Object, packages);

            var packageToUpdate = new Mock<IPackage>();
            packageToUpdate.Setup(x => x.Name).Returns(packageName);
            packageToUpdate.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            // act
            var returndValue = packageRepositroy.Update(packageToUpdate.Object);

            // assert
            Assert.IsTrue(returndValue);
        }

        [Test]
        public void ReturnFalse_WhenPackageIsFoundButHasTheSameVersionAsThePassedPackage()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepositroy = new PackageRepository(loggerStub.Object, packages);

            var packageToUpdate = new Mock<IPackage>();
            packageToUpdate.Setup(x => x.Name).Returns(packageName);
            packageToUpdate.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

            // act
            var returndValue = packageRepositroy.Update(packageToUpdate.Object);

            // assert
            Assert.IsFalse(returndValue);
        }

        [Test]
        public void ThrowArgumentException_WhenPackageIsFoundButHasHigherVersionThanThePassedPackage()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepositroy = new PackageRepository(loggerStub.Object, packages);

            var packageToUpdate = new Mock<IPackage>();
            packageToUpdate.Setup(x => x.Name).Returns(packageName);
            packageToUpdate.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            // act and assert
            Assert.Throws<ArgumentException>(() => packageRepositroy.Update(packageToUpdate.Object));
        }

        [Test]
        public void CallLoggersLogMethodWithStringContainingPackagehasHigherVersion_WhenPassedPackageHasLowerVersionThanTheFoundOne()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepositroy = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdate = new Mock<IPackage>();
            packageToUpdate.Setup(x => x.Name).Returns(packageName);
            packageToUpdate.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            loggerMock.Setup(x => x.Log(It.Is<string>(y => y.Contains("package has higher version"))));

            // act
            var ex = Assert.Throws<ArgumentException>(() => packageRepositroy.Update(packageToUpdate.Object));
            
            // assert
            loggerMock.Verify(x => x.Log(It.Is<string>(y => y.Contains("package has higher version"))), Times.Once);
        }

        [Test]
        public void CallLoggersLogMethodWithStringContainingSameVersion_WhenPackageIsFoundButHasTheSameVersionAsThePassedOne()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();

            string packageName = "someName";
            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Name).Returns(packageName);
            var packages = new List<IPackage>() { presentPackage.Object };

            var packageRepositroy = new PackageRepository(loggerMock.Object, packages);

            var packageToUpdate = new Mock<IPackage>();
            packageToUpdate.Setup(x => x.Name).Returns(packageName);
            packageToUpdate.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

            loggerMock.Setup(x => x.Log(It.Is<string>(y => y.Contains("same version"))));

            // act
            packageRepositroy.Update(packageToUpdate.Object);

            // assert
            loggerMock.Verify(x => x.Log(It.Is<string>(y => y.Contains("same version"))), Times.Once);
        }
    }
}
