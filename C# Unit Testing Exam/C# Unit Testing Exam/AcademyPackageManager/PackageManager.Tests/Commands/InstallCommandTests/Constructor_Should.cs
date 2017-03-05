namespace PackageManager.Tests.Commands.InstallCommandTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using PackageManager.Models.Contracts;
    using Fakes;
    using Enums;
    using PackageManager.Core.Contracts;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetInstallerCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            installerStub.Setup(x => x.Operation);
            // act
            var installCommand = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // assert
            Assert.AreSame(installerStub.Object, installCommand.Installer);
        }

        [Test]
        public void SetPackageCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            installerStub.Setup(x => x.Operation);
            // act
            var installCommand = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // assert
            Assert.AreSame(packageStub.Object, installCommand.Package);
        }

        [Test]
        public void AssingProvidedInstallersOperationPropertyToInstallerOperationInstall_WhenPassedPArametersAreValid()
        {
            // arrange
            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            installerStub.SetupSet(x => x.Operation = It.Is<InstallerOperation>(y => y == InstallerOperation.Install));
            // act
            var installCommand = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // assert
            installerStub.VerifySet(x => x.Operation = It.Is<InstallerOperation>(y => y == InstallerOperation.Install));
        }
    }
}
