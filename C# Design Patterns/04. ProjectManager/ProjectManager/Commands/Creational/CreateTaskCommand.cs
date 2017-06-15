using Bytes2you.Validation;
using ProjectManager.Commands.Abstracts;
using ProjectManager.Commands.Contracts;
using ProjectManager.Data;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using System.Collections.Generic;

namespace ProjectManager.Commands.Creational
{
    public class CreateTaskCommand : Command, ICommand
    {
        private readonly ITaskFactory taskFactory;
        private readonly IAddTask addTask;

        public CreateTaskCommand(IAddTask addTask, ITaskFactory factory) 
            : base(4)
        {
            Guard.WhenArgument(factory, "taskFactory").IsNull().Throw();
            Guard.WhenArgument(addTask, "addTask").IsNull().Throw();

            this.taskFactory = factory;
            this.addTask = addTask;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projectId = int.Parse(parameters[0]);
            var ownerId = int.Parse(parameters[1]);

            this.addTask.AddTask(projectId, ownerId, parameters[2], parameters[3]);

            return "Successfully created a new task!";
        }
    }
}