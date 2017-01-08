namespace Events
{
    using System;
    using System.Threading;

    public delegate void MyDelegate(string input);

    public class Timer 
    {
        public delegate void IntervalEventHandler(object source, TimerEventArgs args);

        public event IntervalEventHandler IntervalReached;

        private int interval;

        public Timer(int interval, MyDelegate executionMethod)
        {
            this.Interval = interval;
            this.ForExecution = executionMethod;
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Timer's interval cannot be zero or less");
                }

                this.interval = value;
            }
        }

        public MyDelegate ForExecution { get; set; }

        public void Start(int totalSeconds)
        {
            var endExecuiton = DateTime.Now.AddMilliseconds(totalSeconds * 1000);

            while (DateTime.Now <= endExecuiton)
            {
                Thread.Sleep(this.interval * 1000);

                this.OnIntervalReached();

            }
        }

        public virtual void OnIntervalReached()
        {
            if (this.IntervalReached != null)
            {
                this.IntervalReached(this, new TimerEventArgs() { Interval = this.Interval, MethodForExecution = this.ForExecution });
            }
        }
    }
}
