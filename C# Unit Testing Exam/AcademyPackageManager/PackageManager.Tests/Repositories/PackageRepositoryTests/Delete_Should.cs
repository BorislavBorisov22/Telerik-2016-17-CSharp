namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Repositories;
    using Moq;
    using Info.Contracts;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;

    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var packageRepo = new PackageRepository(loggerStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Delete(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenNoPassedPackageCannotBeFoundInPackagesCollection()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Equals(It.IsAny<IPackage>()))
                .Returns(false);
            var repositoryPackages = new List<IPackage>() { presentPackage.Object };

            var packageRepo = new PackageRepository(loggerStub.Object, repositoryPackages); ;

            var packageToRemove = new Mock<IPackage>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepo.Delete(packageToRemove.Object));
        }

        [Test]
        public void CallLoggersLogMethodWithStringContainingpackageIsAdependencyAndCouldNotBeRemoved_WhenPackageIsFoundButIsADependencOfOtherPackagesInCollection()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Equals(It.IsAny<IPackage>()))
                .Returns(true);
            
            var dependency = new Mock<IPackage>();
            dependency.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            dependency.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            var dependencies = new List<IPackage>() { dependency.Object };
            presentPackage.Setup(x => x.Dependencies).Returns(dependencies);

            var packageToRemove = new Mock<IPackage>();

            var repositoryPackages = new List<IPackage>() { presentPackage.Object };
            var packageRepo = new PackageRepository(loggerStub.Object, repositoryPackages); ;

            loggerStub.Setup(x => x.Log(It.Is<string>(y => y.Contains("The package is a dependency and could not be removed"))));

            // act
            var ex = Assert.Throws<ArgumentException>(() => packageRepo.Delete(packageToRemove.Object));

            // assert
            loggerStub.Verify(x => x.Log(It.Is<string>(y => y.Contains("The package is a dependency and could not be removed"))), Times.Once);

        }

        [Test]
        public void ReturnTheRemovedPackage_WhenPackageIsSuccessfullyRemoved()
        {
            // arrange
            var loggerStub = new Mock<ILogger>();

            var presentPackage = new Mock<IPackage>();
            presentPackage.Setup(x => x.Equals(It.IsAny<IPackage>()))
                .Returns(true);
           
            var dependencies = new List<IPackage>();
            presentPackage.Setup(x => x.Dependencies).Returns(dependencies);

            var packageToRemove = new Mock<IPackage>();

            var repositoryPackages = new List<IPackage>() { presentPackage.Object };
            var packageRepo = new PackageRepository(loggerStub.Object, repositoryPackages); ;

            // act
            var returnedObj = packageRepo.Delete(packageToRemove.Object);

            // assert
            Assert.AreSame(packageToRemove.Object, returnedObj);
        }
    }
}
