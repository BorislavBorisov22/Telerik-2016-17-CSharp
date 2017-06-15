using Bytes2you.Validation;
using Dealership.Engine;
using Dealership.Engine.Providers;
using System.Linq;

namespace Dealership.CommandHandlers
{
    public class LoginUserHandler : CommandHandler
    {
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";

        private readonly IUserProvider userProvider;

        public LoginUserHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Login";
        }

        protected override string Process(ICommand command)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            return this.Login(username, password);
        }

        private string Login(string username, string password)
        {
            if (this.userProvider.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, this.userProvider.LoggedUser.Username);
            }

            var userFound = this.userProvider.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                this.userProvider.LoggedUser = userFound;
                return string.Format(UserLoggedIn, username);
            }

            return WrongUsernameOrPassword;
        }
    }
}
