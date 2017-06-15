using Bytes2you.Validation;
using ProjectManager.Commands.Abstracts;
using ProjectManager.Commands.Contracts;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using System.Collections.Generic;

namespace ProjectManager.Commands.Creational
{
    public class CreateUserCommand : Command, ICommand
    {
        private readonly IUserFactory userFactory;
        private readonly IAddUser addUser;

        public CreateUserCommand(IAddUser addUser, IUserFactory factory) 
            : base(3)
        {
            Guard.WhenArgument(factory, "userFactory").IsNull().Throw();
            Guard.WhenArgument(addUser, "addUser").IsNull().Throw();

            this.userFactory = factory;
            this.addUser = addUser;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projectId = int.Parse(parameters[0]);

            var user = this.userFactory.CreateUser(parameters[1], parameters[2]);
            this.addUser.AddUser(projectId, user);

            return "Successfully created a new user!";
        }
    }
}
