using Academy.CLI.Configuration;
using Academy.CLI.Interceptors;
using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Data;
using Academy.Data.Contracts;
using Academy.Framework.Commands.Creating;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using System.Linq;

namespace Academy.CLI.Container
{
    public class AcademyModule : NinjectModule
    {
        private const string AddStudentToCourseCommandName = "AddStudentToCourse";
        private const string AddStudentToSeasonCommandName = "AddStudentToSeason";
        private const string AddTrainerToSeasonCommandName = "AddTrainerToSeason";

        private const string CreateCourseCommandName = "CreateCourse";
        private const string CreateCourseResultCommandName = "CreateCourseResult";
        private const string CreateLectureCommandName = "CreateLecture";
        private const string CreateSeasonCommandName = "CreateSeason";
        private const string CreateStudentCommandName = "CreateStudent";
        private const string CreateTrainerCommandName = "CreateTrainer";
        private const string CreateLectureResourceCommandName = "CreateLectureResource";


        private const string ListCoursesInSeasonCommandName = "ListCoursesInSeason";
        private const string ListUsersCommandName = "ListUsers";
        private const string ListUsersInSeasonCommandName = "ListUsersInSeason";

        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            // providers
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            var commandProcessorBinding = this.Bind<IParser>().To<CommandParser>().InSingletonScope();

            // commands
            // adding
            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named(AddStudentToCourseCommandName);
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named(AddStudentToSeasonCommandName);
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named(AddTrainerToSeasonCommandName);
            // creating
            this.Bind<ICommand>().To<CreateCourseCommand>().Named(CreateCourseCommandName);
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named(CreateCourseResultCommandName);
            this.Bind<ICommand>().To<CreateLectureCommand>().Named(CreateLectureCommandName);
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named(CreateSeasonCommandName);
            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named(CreateTrainerCommandName);
            this.Bind<ICommand>().To<CreateLectureResourceCommand>().Named(CreateLectureResourceCommandName);
            // listing
            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named(ListCoursesInSeasonCommandName);
            this.Bind<ICommand>().To<ListUsersCommand>().Named(ListUsersCommandName);
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named(ListUsersInSeasonCommandName);

            // factories
            this.Bind<ICommandFactory>().ToFactory();
            this.Bind<IAcademyFactory>().To<AcademyFactory>();
            this.Bind<ICommand>().ToMethod(context =>
            {
                string commandName = (string)context.Parameters.First().GetValue(context, null);
                var command = context.Kernel.Get<ICommand>(commandName);

                return command;
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            // data
            this.Bind<IAcademyData>().To<AcademyData>().InSingletonScope();

            // configurations
            this.Bind<IConfiguratorProvider>().To<ConfiguratorProvider>();

            var configration = this.Kernel.Get<IConfiguratorProvider>();
            if (configration.IsTestEnvironment)
            {
                commandProcessorBinding.Intercept().With<StopwatchInterceptor>();
            }

            this.Kernel.InterceptAfter<ConsoleWriter>(w => w.Write(null), invocation =>
            {
                System.Console.WriteLine("");
            });
        }
    }
}
