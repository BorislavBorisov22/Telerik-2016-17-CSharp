namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Messages
    {
        public static StringBuilder Output { get; set; }

        public static void EventAdded()
        {
            Output.Append("Event added\n");
        }

        public static void EventDeleted(int eventsDeletedCount)
        {
            if (eventsDeletedCount == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted\n", eventsDeletedCount);
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}
