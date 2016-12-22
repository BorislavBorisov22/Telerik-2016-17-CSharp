namespace GSM.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private static readonly GSM iphone4S = new GSM("Iphone 4S", "Apple", 400);

        private string model;
        private string manufacturer;
        private decimal? price;
        private List<Call> callHistory;

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.callHistory = new List<Call>();
        }

        public static GSM Iphone4S
        {
            get { return iphone4S; }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM model cannot be empty, whitespace or null");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("GSM Manufacturer cannot be empty, null or whitespace");
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("GSM price cannot be zero or less");
                }

                this.price = value;
            }
        }

        public string Owner { get; set; }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public string CallHistory
        {
            get
            {
                if (this.callHistory.Count == 0)
                {
                    return "Call history is empty";
                }

                var callsInfo = new StringBuilder();

                foreach (var call in this.callHistory)
                {
                    callsInfo.AppendLine(call.ToString())
                        .AppendLine("---------------------------");
                }

                return callsInfo.ToString().Trim();
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("Model: {0, -10}", this.Model))
                .AppendLine(string.Format("Manufacturer: {0, -10}", this.Manufacturer))
                .AppendLine(string.Format("Price: {0, -10}", this.Price + "$"))
                .AppendLine(string.Format("Owner: {0, -10}", this.Owner))
                .AppendLine(string.Format("Battery: {0, -10}", this.Battery))
                .AppendLine(string.Format("Display: {0, -10}", this.Display));

            return output.ToString().Trim();
        }

        public void AddCall(DateTime date, string dialedNumber, int duration)
        {
            this.callHistory.Add(new Call(date, dialedNumber, duration));
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        // removes call at given position
        public void DeleteCall(int callPositionInHistory)
        {
            if (callPositionInHistory > this.callHistory.Count)
            {
                throw new ArgumentOutOfRangeException("Such call does not exist in the call history!");
            }

            this.callHistory.RemoveAt(callPositionInHistory - 1);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public decimal TotalCallsPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;

            foreach (var call in this.callHistory)
            {
                int minutesCall = call.Duration / 60;
                int secondsCall = call.Duration % 60;

                totalPrice += minutesCall * pricePerMinute;

                if (secondsCall > 0)
                {
                    totalPrice += pricePerMinute;
                }
            }

            return totalPrice;
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public void RemoveLongestCall()
        {
            int maxCallDuration = 0;
            int maxCallIndex = -1;

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i].Duration > maxCallDuration)
                {
                    maxCallDuration = this.callHistory[i].Duration;
                    maxCallIndex = i;
                }
            }

            this.callHistory.RemoveAt(maxCallIndex);
        }
    }
}
