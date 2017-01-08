namespace Timer
{
    using System;
    using System.Threading;

    public delegate void MyDelegate(string input);

    public class Timer
    {
        private int interval;

        public Timer(int interval, MyDelegate methodForExecution)
        {
            this.Interval = interval;
            this.ExecutionMethod = methodForExecution;
        }

        public MyDelegate ExecutionMethod { get; set; }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Time's interval for method execution cannot be zero or less");
                }
                this.interval = value;
            }
        }

        public void Start(int totalSeconds)
        {
            var endOfExecution = DateTime.Now.AddMilliseconds(totalSeconds * 1000);

            while (DateTime.Now <= endOfExecution)
            {
                this.ExecutionMethod(string.Format("I am beign executed in every {0} seconds", this.Interval));
                Thread.Sleep(this.interval * 1000);
            }
        }
    }
    
}
