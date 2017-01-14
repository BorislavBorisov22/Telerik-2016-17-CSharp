namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerday) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerday;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Worker's week salary cannot be zero or less");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Worker's work hours per day cannot be zero or less");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return weekSalary / 5 / workHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" -> money per hour: {0}", this.MoneyPerHour());
        }
    }
}