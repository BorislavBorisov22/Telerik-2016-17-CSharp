namespace Dealership.Tests.Models.CommentTests
{
    using System;

    using NUnit.Framework;
    using Engine;
    using Dealership.Models;

    [TestFixture]
    public class CommentConstructor_Should
    {
        [Test]
        public void AssingContentsCorrectly_WhenObjectIsConstructed()
        {
            // arrange and act
            string content = "Some random content";
            var comment = new Comment(content);

            // assert
            Assert.AreEqual(content, comment.Content);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedContentIsNull()
        {
            // arrange
            string content = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Comment(content));
        }

        [TestCase("so")]
        [TestCase(@"ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ThrowArgumentException_WhenPassedContentLegnthIsInvalid(string content)
        {
            Assert.Throws<ArgumentException>(() => new Comment(content));
        }
    }
}
