namespace Dealership.Tests.Engine.CommandTests.Fakes
{
    using Dealership.Engine;

    public class CommandFake : Command
    {
        public CommandFake(string input) 
            : base(input)
        {
        }

        public bool IsTranslateInputCalled { get; set; }

        protected override void TranslateInput(string input)
        {
            this.IsTranslateInputCalled = true;
        }
    }
}
