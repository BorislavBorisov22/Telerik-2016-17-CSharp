namespace Dealership.Tests.Models.CommentTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;

    [TestFixture]
    public class SetAuthor_Should
    {
        [Test]
        public void AssignPassedValue_WhenAssigningValidAuthor()
        {
            // arrange
            string content = "some content";
            var comment = new Comment(content);
            string author = "Ivan Vazov";

            // act
            comment.Author = author;

            // assert
            Assert.AreEqual(author, comment.Author);
        }
    }
}
