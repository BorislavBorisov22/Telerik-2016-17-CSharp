using Bytes2you.Validation;
using Dealership.Common;
using Dealership.Engine;
using Dealership.Engine.Providers;
using System.Linq;

namespace Dealership.CommandHandlers
{
    public class RemoveCommentHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        private readonly IUserProvider userProvider;

        public RemoveCommentHandler(IUserProvider userProvider)
        {
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveComment";
        }

        protected override string Process(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            return this.RemoveComment(vehicleIndex, commentIndex, username);
        }

        private string RemoveComment(int vehicleIndex, int commentIndex, string username)
        {
            var user = this.userProvider.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            Validator.ValidateIntRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            this.userProvider.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(CommentRemovedSuccessfully, this.userProvider.LoggedUser.Username);
        }
    }
}
