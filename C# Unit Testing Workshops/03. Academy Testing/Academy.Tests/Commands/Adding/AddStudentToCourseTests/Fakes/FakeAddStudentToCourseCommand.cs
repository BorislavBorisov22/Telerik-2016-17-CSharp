namespace Academy.Tests.Commands.Adding.AddStudentToCourseTests.Fakes
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;

    internal class FakeAddStudentToCourseCommand : AddStudentToCourseCommand
    {
        public FakeAddStudentToCourseCommand(IAcademyFactory factory, IEngine engine) 
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
