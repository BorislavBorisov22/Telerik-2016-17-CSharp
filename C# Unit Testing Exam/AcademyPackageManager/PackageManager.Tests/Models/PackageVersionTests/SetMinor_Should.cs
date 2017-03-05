namespace PackageManager.Tests.Models.PackageVersionTests
{
    using System;

    using NUnit.Framework;
    using Enums;
    using PackageManager.Models;

    [TestFixture]
    public class SetMinor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedMinorIsInInvalidTRange()
        {
            // arrange
            int major = 1;
            int invalidMinor = -1;
            int patch = 3;
            var versionType = VersionType.alpha;

            // act and assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, invalidMinor, patch, versionType));
        }

        [Test]
        public void AssignToMinorCorrectly_WhenPassedMinorRangeIsValid()
        {
            // arrange
            int major = 1;
            int validMinor = 2;
            int patch = 3;
            var versionType = VersionType.alpha;
            

            // act
            var package = new PackageVersion(major, validMinor, patch, versionType);

            // assert
            Assert.AreEqual(package.Minor, validMinor);
        }
    }
}
