namespace StudentsAndWorkers
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) 
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Student's grade cannot be less than one and more than 12");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("-> {0} Grade",this.Grade);
        }
    }
}
