namespace PackageManager.Tests.Core.PackageInstallerTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using Moq;
    using System.Collections.Generic;
    using PackageManager.Core.Contracts;
    using PackageManager.Core;
    using Enums;

    [TestFixture]
    public class PerformOperation_Should
    {
        [Test]
        public void CallOneTimeRemoveOfDownloader_WhenThereIsOnlyOnePackageToRestoreWithEmptyDependenciesList()
        {
            // arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            downloaderStub.Setup(x => x.Remove(It.IsAny<string>()));

            var packageStub = new Mock<IPackage>();
            var dependenciesList = new List<IPackage>();
            packageStub.Setup(x => x.Dependencies).Returns(dependenciesList);

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloaderStub.Object, projectStub.Object);

            // act
            installer.PerformOperation(packageStub.Object);

            // assert
            downloaderStub.Verify(x => x.Remove(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallTwoTimesDownloadOfDownloader_WhenThereIsOnlyOnePackageToRestoreWithEmptyDependenciesList()
        {
            // arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            downloaderStub.Setup(x => x.Download(It.IsAny<string>()));

            var packageStub = new Mock<IPackage>();
            var dependenciesList = new List<IPackage>();
            packageStub.Setup(x => x.Dependencies).Returns(dependenciesList);

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloaderStub.Object, projectStub.Object);

            // act
            installer.PerformOperation(packageStub.Object);

            // assert
            downloaderStub.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void CallTwoTimesRemoveOfDownloader_WhenThereIsOnlyOnePackageToRestoreWithOneDependencyOnTheChain()
        {
            // arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            downloaderStub.Setup(x => x.Remove(It.IsAny<string>()));

            var packageStub = new Mock<IPackage>();

            var dependencyPackage = new Mock<IPackage>();
            var dependenciesOfDependency = new List<IPackage>();
            dependencyPackage.Setup(x => x.Dependencies).Returns(dependenciesOfDependency);

            var dependenciesList = new List<IPackage>() { dependencyPackage.Object };
            packageStub.Setup(x => x.Dependencies).Returns(dependenciesList);

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloaderStub.Object, projectStub.Object);
            installer.Operation = InstallerOperation.Install;

            // act
            installer.PerformOperation(packageStub.Object);

            // assert
            downloaderStub.Verify(x => x.Remove(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void CallFourTimesDownloadOfDownloader_WhenThereIsOnlyOnePackageToRestoreWithOneDependencyOnTheChain()
        {
            // arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());
            downloaderStub.Setup(x => x.Download(It.IsAny<string>()));

            var packageStub = new Mock<IPackage>();

            var dependencyPackage = new Mock<IPackage>();
            var dependenciesOfDependency = new List<IPackage>();
            dependencyPackage.Setup(x => x.Dependencies).Returns(dependenciesOfDependency);

            var dependenciesList = new List<IPackage>() { dependencyPackage.Object };
            packageStub.Setup(x => x.Dependencies).Returns(dependenciesList);

            
            var installer = new PackageInstaller(downloaderStub.Object, projectStub.Object);
            installer.Operation = InstallerOperation.Install;

            // act
            installer.PerformOperation(packageStub.Object);

            // assert
            downloaderStub.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
