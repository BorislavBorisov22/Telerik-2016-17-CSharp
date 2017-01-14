namespace PersonClass
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty or null");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Persons age cannot be negative");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Name: {0}", this.Name));

            if (this.Age == null)
            {
                output.AppendLine(string.Format("Age: not specified"));
            }
            else
            {
                output.AppendLine(string.Format("Age: {0}", this.Age));
            }

            return output.ToString().Trim();
        }

    }
}
