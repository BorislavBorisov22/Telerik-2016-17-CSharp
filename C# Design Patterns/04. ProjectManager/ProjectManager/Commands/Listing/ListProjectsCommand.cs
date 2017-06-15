using Bytes2you.Validation;
using ProjectManager.Commands.Abstracts;
using ProjectManager.Commands.Contracts;
using ProjectManager.Data.Data.Contracts;
using System;
using System.Collections.Generic;

namespace ProjectManager.Commands.Listing
{
    public class ListProjectsCommand : Command, ICommand
    {
        private readonly IProjectsInfo projectsInfo;

        public ListProjectsCommand(IProjectsInfo projectsInfo) 
            : base(0)
        {
            Guard.WhenArgument(projectsInfo, "projectsInfo").IsNull().Throw();

            this.projectsInfo = projectsInfo;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projects = this.projectsInfo.GetProjectsInfo();
            return projects;
        }
    }
}
