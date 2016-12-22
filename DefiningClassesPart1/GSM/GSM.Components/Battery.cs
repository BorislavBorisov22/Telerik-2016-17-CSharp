namespace GSM.Components
{
    using System;
    using System.Text;

    public class Battery
    {
        // fields
        private int? hoursIdle;
        private int? hoursTalk;

        // constructors
        public Battery(BatteryType? typeBattery = null, int? hoursIdle = null, int? hoursTalk = null)
        {
            this.Type = typeBattery;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        // properties
        public BatteryType? Type { get; set; }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Hours idle cannot be zero or less");
                }

                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk cannot be zero or less");
                }

                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Type: {0}, Hours Idle: {1}, Hours Talk: {2}", this.Type, this.HoursIdle, this.HoursTalk);

            return output.ToString().Trim();
        }
    }
}
