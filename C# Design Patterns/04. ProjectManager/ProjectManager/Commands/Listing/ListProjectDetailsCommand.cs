using Bytes2you.Validation;
using ProjectManager.Commands.Abstracts;
using ProjectManager.Commands.Contracts;
using ProjectManager.Data.Data.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Commands.Listing
{
    public class ListProjectDetailsCommand : Command, ICommand
    {
        private readonly IProjectInfo projectInfo;

        public ListProjectDetailsCommand(IProjectInfo projectInfo) 
            : base(1)
        {
            Guard.WhenArgument(projectInfo, "projectInfo").IsNull().Throw();

            this.projectInfo = projectInfo;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projectId = int.Parse(parameters[0]);
            var project = this.projectInfo.GetProjectInfo(projectId);

            return project;
        }
    }
}
