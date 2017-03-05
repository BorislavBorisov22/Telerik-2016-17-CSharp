using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.PackageInstallerTests.Fakes
{
    internal class FakePackageInstaller : PackageInstaller
    {
        public FakePackageInstaller(IDownloader downloader, IProject project) 
            : base(downloader, project)
        {
        }

        public int PerformOperationCalls { get; set; }
       

        public override void PerformOperation(IPackage package)
        {
            this.PerformOperationCalls++;
        }
    }
}
