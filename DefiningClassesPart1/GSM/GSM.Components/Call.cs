namespace GSM.Components
{
    using System;
    using System.Text;

    public class Call
    {
        private string dialedNumber;
        private int duration;

        public Call(DateTime date, string dialedNumber, int duration)
        {
            this.Date = date;
            this.Time = string.Format("{0}:{1}", date.TimeOfDay.Hours, date.TimeOfDay.Minutes);
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public DateTime Date { get; private set; }

        public string Time { get; private set; }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }

            private set
            {
                if (!this.IsValidNumber(value))
                {
                    throw new ArgumentException("Invalid phone number. Number should contain only digits (plus in the beginning is optional)");
                }

                this.dialedNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Call duration cannot be zero or less");
                }

                this.duration = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Date: {0}, Time: {1}, Dialled number: {2}, Duration: {3}", this.Date, this.Time, this.DialedNumber, this.Duration);

            return output.ToString().Trim();
        }

        private bool IsValidNumber(string phoneNumber)
        {
            if (phoneNumber.Length < 10)
            {
                return false;
            }

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (i == 0 && phoneNumber[0] == '+')
                {
                    continue;
                }

                if (!char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
