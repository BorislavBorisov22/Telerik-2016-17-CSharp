using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Data;
using SchoolSystem.Framework.Data.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public const string CreateStudentCommandName = "CreateStudent";
        public const string CreateTeacherCommandName = "CreateTeacher";
        public const string RemoveStudentCommandName = "RemoveStudent";
        public const string RemoveTeacherCommandName = "RemoveTeacher";
        public const string StudentListMarksCommandName = "StudentListMarks";
        public const string TeacherAddMarkCommandName = "TeacherAddMark";

        public override void Load()
        {
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            this.Bind<ISchoolSystemData>().To<SchoolSystemData>().InSingletonScope();

            this.Bind<ICommand>().To<CreateStudentCommand>().InSingletonScope().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().InSingletonScope().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ITeacher>().To<Teacher>();
            this.Bind<IMark>().To<Mark>();
            this.Bind<IStudent>().To<Student>();

            var markFactory = this.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            var studentFactory = this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var commandFactory = this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                markFactory.Intercept().With<PerformanceMeasurerInterpcetor>();
                studentFactory.Intercept().With<PerformanceMeasurerInterpcetor>();
                commandFactory.Intercept().With<PerformanceMeasurerInterpcetor>();
            }

            // for command factory
            this.Bind<ICommand>().ToMethod(context =>
            {
                IList<IParameter> contextParams = context.Parameters.ToList();
                var commandName = (string)contextParams[0].GetValue(context, null);
                
                return context.Kernel.Get<ICommand>(commandName);
            }).NamedLikeFactoryMethod((ICommandFactory factory) => factory.GetCommand(null));
        }
    }
}