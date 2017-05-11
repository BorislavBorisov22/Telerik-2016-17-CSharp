using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Person : IPerson
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;

        private string firstName;
        private string lastName;
        private IValidator validator;

        public Person(string firstName, string lastName, IValidator validator = null)
        {
            this.Validator = validator;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.Validator.ValidateValueRange(MinNameLength, MaxNameLength, value.Length, $"FirstName must be between {MinNameLength} and {MaxNameLength} symbols");
                this.Validator.ValidateStringLatinLetters(value, "Names must consist only of lating letters!");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.Validator.ValidateValueRange(MinNameLength, MaxNameLength, value.Length, $"LastName must be between {MinNameLength} and {MaxNameLength} symbols");
                this.Validator.ValidateStringLatinLetters(value, "Names must consist only of lating letters!");

                this.lastName = value;
            }
        }

        protected IValidator Validator
        {
            get
            {
                return this.validator;
            }

            private set
            {
                if (value == null)
                {
                    this.validator = new Validator();
                }
                else
                {
                    this.validator = value;
                }
            }
        }
    }
}
