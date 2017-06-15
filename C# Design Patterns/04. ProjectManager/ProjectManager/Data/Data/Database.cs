using ProjectManager.Data.Models.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data.Factories;
using Bytes2you.Validation;

namespace ProjectManager.Data
{
    public class Database : IDatabase
    {
        private readonly IList<IProject> projects;
        private readonly ITaskFactory taskFactory;

        public Database(ITaskFactory taskFactory)
        {
            Guard.WhenArgument(taskFactory, "taskFactory").IsNull().Throw();

            this.taskFactory = taskFactory;
            this.projects = new List<IProject>();
        }

        public void AddProject(IProject project)
        {
            if (this.projects.Any(x => x.Name == project.Name))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            this.projects.Add(project);
        }

        public void AddTask(int projectId, int ownerId, string taskName, string taskState)
        {
            var project = this.projects[projectId];
            var owner = project.Users[ownerId];

            var task = this.taskFactory.GetTask(owner, taskName, taskState);
            project.Tasks.Add(task);
        }

        public void AddUser(int projectId, IUser user)
        {
            var project = this.projects[projectId];

            if (project.Users.Any() && project.Users.Any(x => x.Username == user.Username))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            project.Users.Add(user);
        }

        public string GetProjectInfo(int projectId)
        {
            var project = this.projects[projectId];

            return project.ToString();
        }

        public string GetProjectsInfo()
        {
            var projects = string.Join(Environment.NewLine, this.projects);
            return projects;
        }
    }
}
