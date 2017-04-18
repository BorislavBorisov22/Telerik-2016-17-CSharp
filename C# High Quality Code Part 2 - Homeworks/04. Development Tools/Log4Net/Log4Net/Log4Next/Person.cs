namespace Log4Net
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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
                    throw new ArgumentException($"{value} is an invalid name! Name must not be null!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Age must be a positive number!");
                }

                this.age = value;
            }
        }
    }
}
