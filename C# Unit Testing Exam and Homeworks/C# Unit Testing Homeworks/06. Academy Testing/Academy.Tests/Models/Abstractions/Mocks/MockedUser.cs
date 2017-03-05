namespace Academy.Tests.Models.Abstractions.Mocks
{
    using Academy.Models.Abstractions;

    public class MockedUser : User
    {
        public MockedUser(string username) 
            : base(username)
        {
        }
    }
}
