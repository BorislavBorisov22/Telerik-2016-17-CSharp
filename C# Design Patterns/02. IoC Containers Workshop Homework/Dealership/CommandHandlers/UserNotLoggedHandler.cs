using Bytes2you.Validation;
using Dealership.Engine;
using Dealership.Engine.Providers;

namespace Dealership.CommandHandlers
{
    public class UserNotLoggedHandler : CommandHandler
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IUserProvider userProvider;

        public UserNotLoggedHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name != "RegisterUser" &&
                command.Name != "Login" &&
                this.userProvider.LoggedUser == null;
        }

        protected override string Process(ICommand command)
        {
            return UserNotLogged;
        }
    }
}
