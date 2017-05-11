namespace SchoolSystem.Tests.Models.Person.Fakes
{
    using SchoolSystem.Contracts;
    using SchoolSystem.Models;

    internal class FakePerson : Person
    {
        public FakePerson(string firstName, string lastName, IValidator validator = null) 
            : base(firstName, lastName, validator)
        {
        }

        public IValidator ValidatorExposed
        {
            get
            {
                return this.Validator;
            }
        }
    }
}
