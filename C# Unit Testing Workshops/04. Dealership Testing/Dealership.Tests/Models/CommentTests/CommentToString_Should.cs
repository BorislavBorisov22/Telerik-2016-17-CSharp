namespace Dealership.Tests.Models.CommentTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;

    [TestFixture]
    public class CommentToString_Should
    {
        [Test]
        public void ReturnStringThatConatinsUserWord_WhenCalled()
        {
            // arrange
            string content = "some content";
            var comment = new Comment(content);

            string expectedToHaveString = "User:";
            // act
            string returnedString = comment.ToString();

            // assert
            StringAssert.Contains(expectedToHaveString, returnedString);
        }
    }
}
