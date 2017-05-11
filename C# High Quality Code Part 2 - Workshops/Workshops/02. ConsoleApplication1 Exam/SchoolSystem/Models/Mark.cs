using SchoolSystem.Contracts;
using SchoolSystem.Enums;

namespace SchoolSystem.Models
{
   public class Mark : IMark
    {
        private const int MinMarkValue = 2;
        private const int MaxMarkValue = 6;

        private float value;

        // internal Subject subject;
        private IValidator validator;

        public Mark(Subject subject, float value, IValidator validator = null)
        {
            this.Validator = validator;

            this.Subject = subject;
            this.Value = value;
        }

        public IValidator Validator
        {
            get
            {
                return this.validator;
            }

            private set
            {
                if (value == null)
                {
                    this.validator = new Validator();
                }
                else
                {
                    this.validator = value;
                }
            }
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                this.validator.ValidateValueRange(MinMarkValue, MaxMarkValue, value, $"Mark must be between {MinMarkValue} and {MaxMarkValue}!");

                this.value = value;
            }
        }

        public Subject Subject { get; private set; }
    }
}
