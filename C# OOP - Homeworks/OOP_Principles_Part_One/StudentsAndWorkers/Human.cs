using System;

namespace StudentsAndWorkers
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
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
                ValidateName(value);
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
                ValidateName(value);
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        private void ValidateName(string name)
        {
            if (name.Length < 3)
            {
                throw new ArgumentOutOfRangeException("A human's name cannot be less than 3 symbols long");
            }
        }
    }
}
