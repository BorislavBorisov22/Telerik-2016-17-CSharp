using Bytes2you.Validation;
using Dealership.Engine;
using Dealership.Engine.Providers;
using System;

namespace Dealership.CommandHandlers
{
    public class LogoutUserHandler : CommandHandler
    {
        private const string UserLoggedOut = "You logged out!";

        private IUserProvider userProvider;

        public LogoutUserHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Logout";
        }

        protected override string Process(ICommand command)
        {
            this.userProvider.LoggedUser = null;
            return UserLoggedOut;
        }
    }
}
