namespace Academy.Tests.Models.Abstractions.UserTests.Fakes
{
    using Academy.Models.Abstractions;

    public class FakeUser : User
    {
        public FakeUser(string username) 
            : base(username)
        {
        }
    }
}
