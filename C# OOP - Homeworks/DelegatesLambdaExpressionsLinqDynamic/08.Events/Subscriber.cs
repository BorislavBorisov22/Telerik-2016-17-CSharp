namespace Events
{
    public class Subscriber
    {
        public void OnIntervalReached(object source, TimerEventArgs e)
        {
            e.MethodForExecution(string.Format("In every {0} seconds the event is raised and handled here",e.Interval));
        }
    }
}
