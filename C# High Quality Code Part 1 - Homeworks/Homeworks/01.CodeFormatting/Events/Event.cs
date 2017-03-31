namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;

            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            int comparedByDate = this.Date.CompareTo(other.Date);
            int comapredByTitle = this.Title.CompareTo(other.Title);
            int comparedByLocation = this.Location.CompareTo(other.Location);

            if (comparedByDate == 0)
            {
                if (comapredByTitle == 0)
                {
                    return comparedByLocation;
                }
                else
                {
                    return comapredByTitle;
                }
            }
            else
            {
                return comparedByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));

            toString.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                toString.Append(" | " + this.Location);
            }

            return toString.ToString();
        }
    }
}
