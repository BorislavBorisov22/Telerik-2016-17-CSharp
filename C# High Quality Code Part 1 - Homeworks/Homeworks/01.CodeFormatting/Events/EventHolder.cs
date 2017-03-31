namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> storedByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> storedByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.storedByTitle.Add(title.ToLower(), newEvent);
            this.storedByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();

            int removed = 0;
            foreach (var eventToRemove in this.storedByTitle[title])
            {
                removed++;
                this.storedByDate.Remove(eventToRemove);
            }

            this.storedByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.storedByDate.RangeFrom(
                new Event(date, string.Empty, string.Empty),
                    true);

            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
