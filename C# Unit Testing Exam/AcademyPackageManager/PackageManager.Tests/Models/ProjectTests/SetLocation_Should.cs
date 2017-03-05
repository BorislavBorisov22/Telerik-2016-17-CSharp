namespace PackageManager.Tests.Models.ProjectTests
{
    using System;

    using NUnit.Framework;
    using PackageManager.Models;

    [TestFixture]
    public class SetLocation_Should
    {
        [Test]
        public void AssignToLocationCorrectly_WhenAllPasedValuesAreValid()
        {
            // arrange
            string name = "validName";
            string location = "validLocation";

            // act
            var project = new Project(name, location);

            // assert
            Assert.AreEqual(location, project.Location);
        }
    }
}
