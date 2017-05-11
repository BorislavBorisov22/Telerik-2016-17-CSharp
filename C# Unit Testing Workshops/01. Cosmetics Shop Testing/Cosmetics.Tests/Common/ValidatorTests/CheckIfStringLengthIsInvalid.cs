namespace Cosmetics.Tests.Common.ValidatorTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class CheckIfStringLengthIsInvalid
    {
        [TestCase("i")]
        [TestCase("some very very long string that will most cerainly throw an expection when validated")]
        public void ThrowIndexOutOfRangeException_WhenLengthOfStringISLowerThanMinimumOrGreaterThanMaximumLength(string inputStr)
        {
            // arrange
            int min = 2;
            int max = 10;

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(inputStr, max, min));
        }

        [Test]
        public void NotThrow_WhenStringsLengthIsBetweenTheAllowedBoundaries()
        {
            // arrange
            string str = "validString";
            int min = 2;
            int max = 15;

            // act and assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(str, max, min));
        }
    }
}
