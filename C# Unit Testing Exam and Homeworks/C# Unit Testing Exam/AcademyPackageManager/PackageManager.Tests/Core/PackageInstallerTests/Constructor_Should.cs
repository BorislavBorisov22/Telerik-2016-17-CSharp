namespace PackageManager.Tests.Core.PackageInstallerTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;
    using PackageManager.Core;
    using Fakes;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CallRestorePackagesWhichWillResultInPerformingOperationOnEachOfTheRepositoryPackages_WhenObjectIsConstructed()
        {
            // arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            var packageDependency = new Mock<IPackage>();

            var dependencies = new List<IPackage>() { packageDependency.Object };

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Dependencies).Returns(dependencies);

            var packagesToRestore = new List<IPackage>()
            {
                packageStub.Object,
                packageStub.Object,
                packageStub.Object
            };

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(packagesToRestore);

            // act
            var installer = new FakePackageInstaller(downloaderStub.Object, projectStub.Object);

            // assert
            Assert.AreEqual(3, installer.PerformOperationCalls);
        }
    }
}
