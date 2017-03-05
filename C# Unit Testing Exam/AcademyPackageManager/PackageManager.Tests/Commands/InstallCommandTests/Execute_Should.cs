namespace PackageManager.Tests.Commands.InstallCommandTests
{
    using System;

    using NUnit.Framework;
    using Fakes;
    using PackageManager.Models.Contracts;
    using Moq;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;

    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallInstallersPerformOperationMethod_WhenInvoked()
        {
            // arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            installerMock.Setup(x => x.Operation);
            installerMock.Setup(
                x => x.PerformOperation(It.Is<IPackage>(y => y == packageStub.Object)));
            
            var installCommand = new InstallCommand(installerMock.Object, packageStub.Object);

            // act
            installCommand.Execute();

            // assert
            installerMock.Verify(x => x.PerformOperation(It.Is<IPackage>(y => y == packageStub.Object)), Times.Once);
        }
    }
}
