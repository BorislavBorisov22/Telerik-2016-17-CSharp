namespace PackageManager.Tests.Commands.InstallCommandTests
{
    using System;

    using NUnit.Framework;

    using Moq;
    using Fakes;
    using PackageManager.Models.Contracts;
    using PackageManager.Core.Contracts;

    [TestFixture]
    public class SetInstaller_Should
    {
        [Test]
        public void AssignInstallerCorrectly_WhenPassedParameterIsValid()
        {
            // arrange and act
            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            installerStub.Setup(x => x.Operation);
            var installCommand = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // assert
            Assert.AreSame(installerStub.Object, installCommand.Installer);
        }
    }
}
