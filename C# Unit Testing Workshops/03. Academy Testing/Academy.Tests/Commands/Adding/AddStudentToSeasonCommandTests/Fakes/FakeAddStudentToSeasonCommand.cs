using Academy.Commands.Adding;
namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests.Fakes
{
    using System;

    using Academy.Core.Contracts;


    internal class FakeAddStudentToSeasonCommand : AddStudentToSeasonCommand
    {
        public FakeAddStudentToSeasonCommand(IAcademyFactory factory, IEngine engine) 
            : base(factory, engine)
        {
        }

        public IAcademyFactory Factory
        {
            get
            {
                return base.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return base.engine;
            }
        }
    }
}
