namespace PackageManager.Tests.Commands.InstallCommandTests
{
    using System;

    using NUnit.Framework;

    using Moq;
    using PackageManager.Models.Contracts;
    using Fakes;
    using PackageManager.Core.Contracts;

    [TestFixture]
    public class SetPackage_Should
    {
        [Test]
        public void AssignToPackage_WhenPassedParameterIsValid()
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
    }
}
