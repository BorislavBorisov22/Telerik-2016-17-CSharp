namespace PackageManager.Tests.Models.ProjectTests
{
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class SetName_Should
    {
        [Test]
        public void AssingToNameCorreclty_WhenPassedValueIsValid()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";

            // act
            var project = new Project(name, location);

            // assert
            Assert.AreEqual(name, project.Name);
        }
    }
}
