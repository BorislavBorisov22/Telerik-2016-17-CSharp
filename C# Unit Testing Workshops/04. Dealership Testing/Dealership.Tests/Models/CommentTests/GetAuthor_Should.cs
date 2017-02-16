namespace Dealership.Tests.Models.CommentTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;

    [TestFixture]
    public class GetAuthor_Should
    {
        [Test]
        public void ReturnStringDefaultValue_WhenNoAuthorWasAssigned()
        {
            // arrange
            string content = "some ranodm content";
            var comment = new Comment(content);

            // act and assert
            Assert.IsNull(comment.Author);
        }

        [TestCase("Ivan Vazov")]
        [TestCase("")]
        public void ReturnAuthorCorrectly_WhenAuthorIsAssigned(string author)
        {
            // arrange
            string content = "some ranodm content";
            var comment = new Comment(content);
            comment.Author = author;
            // act
            Assert.AreEqual(comment.Author, author);
        }
    }
}
