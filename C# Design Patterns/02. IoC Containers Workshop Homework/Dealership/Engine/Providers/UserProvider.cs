using Bytes2you.Validation;
using Dealership.Contracts;
using Dealership.Models;
using System.Collections.Generic;

namespace Dealership.Engine.Providers
{
    public class UserProvider : IUserProvider
    {
        public UserProvider()
        {
            this.Users = new List<IUser>();
        }

        public IList<IUser> Users { get; private set; }

        public IUser LoggedUser { get;  set; }   

        public void Add(IUser user)
        {
            Guard.WhenArgument(user, "User").IsNull().Throw();

            this.Users.Add(user);
        }
    }
}
