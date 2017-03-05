namespace PackageManager.Tests.Commands.InstallCommandTests.Fakes
{
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;

    internal class FakeInstallCommand : InstallCommand
    {
        public FakeInstallCommand(IInstaller<IPackage> installer, IPackage package) 
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> Installer
        {
            get
            {
                return base.installer;
            }
        }

        public IPackage Package
        {
            get
            {
                return base.package;
            }
        }
    }
}
