namespace Events
{
    using System;

    public class TimerEventArgs : EventArgs
    {
        public MyDelegate MethodForExecution { get; set; }
        public int Interval { get; set; }
    }
}
