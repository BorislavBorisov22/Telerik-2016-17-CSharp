using System.Collections.Generic;
using Dealership.Models;
using Dealership.Contracts;

namespace Dealership.Engine.Providers
{
    public interface IUserProvider
    {
        IUser LoggedUser { get; set; }

        IList<IUser> Users { get; }

        void Add(IUser user);
    }
}