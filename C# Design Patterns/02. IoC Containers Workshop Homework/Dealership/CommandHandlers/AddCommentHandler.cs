using Bytes2you.Validation;
using Dealership.Common;
using Dealership.Engine;
using Dealership.Engine.Providers;
using Dealership.Factories;
using System;
using System.Linq;

namespace Dealership.CommandHandlers
{
    public class AddCommentHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        private readonly IUserProvider userProvider;
        private readonly IDealershipFactory factory;

        public AddCommentHandler(IUserProvider userProvider, IDealershipFactory factory)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.userProvider = userProvider;
            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddComment";
        }

        protected override string Process(ICommand command)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            return this.AddComment(content, vehicleIndex, author);
        }

        private string AddComment(string content, int vehicleIndex, string author)
        {
            var comment = this.factory.GetComment(content);
            comment.Author = this.userProvider.LoggedUser.Username;
            var user = this.userProvider.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(NoSuchUser, author);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            this.userProvider.LoggedUser.AddComment(comment, vehicle);

            return string.Format(CommentAddedSuccessfully, this.userProvider.LoggedUser.Username);
        }
    }
}
