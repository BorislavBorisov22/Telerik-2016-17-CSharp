using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using ProjectManager.Commands.Contracts;
using ProjectManager.Commands.Creational;
using ProjectManager.Commands.Listing;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Container.Interceptors;
using ProjectManager.Data;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using ProjectManager.Data.Models;
using ProjectManager.Data.Models.Contracts;
using ProjectManager.Data.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Container
{
    public class ProjectManagerModule : NinjectModule
    {
        private const string CreateUserCommandName = "createuser";
        private const string CreateTaskCommandName = "createtask";
        private const string CreateProjectCommandName = "createproject";
        private const string ListProjectDetailsCommandName = "listprojectdetails";
        private const string ListProjectsCommandName = "listprojects";

        public override void Load()
        {
            // providers
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ILogger>().To<FileLogger>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            // commands
            this.Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named(CreateUserCommandName);
            this.Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named(CreateTaskCommandName);
            this.Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named(CreateProjectCommandName);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named(ListProjectDetailsCommandName);
            this.Bind<ICommand>().To<ListProjectsCommand>().InSingletonScope().Named(ListProjectsCommandName);
            this.Bind<IValidator>().To<Validator>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            // data
            this.Bind(typeof(IAddProject), typeof(IAddTask), typeof(IAddUser), typeof(IProjectInfo), typeof(IProjectsInfo))
                .To<Database>().InSingletonScope();

             // models
            this.Bind<IUser>().To<User>();

            // factories 
            var userFactoryBinding = this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            var taskFactoryBinding = this.Bind<ITaskFactory>().ToFactory().InSingletonScope();
            var projectFactoryBinding = this.Bind<IProjectFactory>().ToFactory().InSingletonScope();
            var commandFactoryBinding = this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>()
                .ToMethod(context =>
                {
                    string commandName = (string)context.Parameters.First().GetValue(context, null);
                    commandName = commandName.ToLower();

                    ICommand targetCommand = context.Kernel.Get<ICommand>(commandName);

                    return targetCommand;
                }).NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommand(null));

            this.Bind<IProject>().ToMethod(context =>
            {
                IList<IParameter> parameters = context.Parameters.ToList();
                string name = (string)parameters[0].GetValue(context, null);
                string startingDate = (string)parameters[1].GetValue(context, null);
                string endingDate = (string)parameters[2].GetValue(context, null);
                string state = (string)parameters[3].GetValue(context, null);

                DateTime startingDateParsed;
                DateTime endingDateParsed;
                ProjectState stateParsed;

                var startingDateSuccessful = DateTime.TryParse(startingDate, out startingDateParsed);
                var endingDateSuccessful = DateTime.TryParse(endingDate, out endingDateParsed);
                var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

                if (!startingDateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed starting date!");
                }

                if (!endingDateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed ending date!");
                }

                if (!stateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed project state!");
                }

                var project = this.Kernel.Get<Project>(parameters[0],
                    new ConstructorArgument("startingDate", startingDateParsed),
                    new ConstructorArgument("endingDate", endingDateParsed),
                    new ConstructorArgument("state", stateParsed)
                    );

                return project;
            }).NamedLikeFactoryMethod((IProjectFactory factory) => factory.GetProject(null, null, null, null));

            this.Bind<ITask>().ToMethod(context =>
            {
                IList<IParameter> parameters = context.Parameters.ToList();
                string state = (string)parameters[2].GetValue(context, null);

                TaskState stateParsed;
                var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

                if (!stateSuccessful)
                {
                    throw new UserValidationException("Failed to parse the passed Task state!");
                }

                var task = this.Kernel.Get<Task>(parameters[0], parameters[1], new ConstructorArgument("state", stateParsed));

                return task;
            }).NamedLikeFactoryMethod((ITaskFactory factory) => factory.GetTask(null, null, null));

            taskFactoryBinding.Intercept().With<ModelsValidatorInterceptor>();
            projectFactoryBinding.Intercept().With<ModelsValidatorInterceptor>();
            userFactoryBinding.Intercept().With<ModelsValidatorInterceptor>();
        }
    }
}
