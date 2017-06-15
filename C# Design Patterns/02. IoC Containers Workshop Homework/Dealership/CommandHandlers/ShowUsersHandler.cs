using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Engine;
using Dealership.Engine.Providers;
using System.Text;

namespace Dealership.CommandHandlers
{
    public class ShowUsersHandler : CommandHandler
    {
        private const string YouAreNotAnAdmin = "You are not an admin!";

        private readonly IUserProvider userProvider;

        public ShowUsersHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowUsers";
        }

        protected override string Process(ICommand command)
        {
                    return this.ShowAllUsers();
        }

        private string ShowAllUsers()
        {
            if (this.userProvider.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in this.userProvider.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
