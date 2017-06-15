using Bytes2you.Validation;
using ProjectManager.Commands.Abstracts;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands.Creational
{
    public sealed class CreateProjectCommand : Command, ICommand
    {
        private readonly IProjectFactory projectFactory;
        private readonly IAddProject addProject;

        public CreateProjectCommand(IAddProject addProject, IProjectFactory factory)
            : base(4)
        {
            Guard.WhenArgument(factory, "projectFactory").IsNull().Throw();
            Guard.WhenArgument(addProject, "addProject").IsNull().Throw();

            this.projectFactory = factory;
            this.addProject = addProject;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var project = this.projectFactory.GetProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.addProject.AddProject(project); 

            return "Successfully created a new project!";
        }
    }
}
