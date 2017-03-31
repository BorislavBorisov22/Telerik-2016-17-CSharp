namespace Methods.Students
{
    using System;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.ValidateNullOrEmptyString(value, "First name cannot be null or empty!");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.ValidateNullOrEmptyString(value, "Last name cannot be null or empty!");

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                Validator.ValidateNullOrEmptyString(value, "OtherInfo cannot be null or empty!");

                this.otherInfo = value;
            }
        }

        public DateTime BirthDate { get; private set; }

        public bool IsOlderThan(IStudent other)
        {
            bool isOlder = this.BirthDate < other.BirthDate;

            return isOlder;
        }
    }
}
