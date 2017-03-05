namespace PackageManager.Tests.Repositories.PackageRepositoryTests.Fakes
{
    using System.Collections.Generic;
    using Info.Contracts;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;

    public class FakePackageRepository : PackageRepository
    {
        public FakePackageRepository(ILogger logger, ICollection<IPackage> packages = null) 
            : base(logger, packages)
        {
        }

        public ICollection<IPackage> Packages
        {
            get
            {
                return base.packages;
            }
        }

        public bool IsUpdateCalled { get; set; }
       

        public override bool Update(IPackage package)
        {
            this.IsUpdateCalled = true;
            return true;
        }
    }
}
