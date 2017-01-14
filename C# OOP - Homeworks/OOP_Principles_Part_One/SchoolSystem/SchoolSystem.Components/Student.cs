namespace SchoolSystem.Components
{
    using System;

    public class Student : Person, ICommentable, INamable, IStudent
    {
        private int classNumber;

        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, string comment, int classNumber)
            : base(name, comment)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Student's class number cannot be negative");
                }

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Class number: {0}", this.ClassNumber);
        }
    }
}