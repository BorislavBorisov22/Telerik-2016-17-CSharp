using System;

using Dealership.Engine;
using Dealership.Engine.Providers;
using Dealership.Factories;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using System.Linq;

namespace Dealership.CommandHandlers
{
    public class RegisterUserHandler : CommandHandler
    {
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        private readonly IUserProvider userProvider;
        private readonly IDealershipFactory factory;

        public RegisterUserHandler(IUserProvider userProvider, IDealershipFactory factory)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.userProvider = userProvider;
            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RegisterUser";
        }

        protected override string Process(ICommand command)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            return this.RegisterUser(username, firstName, lastName, password, role);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, Role role)
        {
            if (this.userProvider.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, this.userProvider.LoggedUser.Username);
            }

            if (this.userProvider.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(UserAlreadyExist, username);
            }

            var user = this.factory.GetUser(username, firstName, lastName, password, role.ToString());
            this.userProvider.LoggedUser = user;
            this.userProvider.Add(user);

            return string.Format(UserRegisterеd, username);
        }
    }
}
