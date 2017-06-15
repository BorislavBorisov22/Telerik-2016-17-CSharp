using Bytes2you.Validation;
using Dealership.Engine;
using Dealership.Engine.Providers;
using System.Linq;

namespace Dealership.CommandHandlers
{
    public class ShowVehiclesHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";

        private readonly IUserProvider userProvider;

        public ShowVehiclesHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowVehicles";
        }

        protected override string Process(ICommand command)
        {
            var username = command.Parameters[0];

            return this.ShowUserVehicles(username);
        }

        private string ShowUserVehicles(string username)
        {
            var user = this.userProvider.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
