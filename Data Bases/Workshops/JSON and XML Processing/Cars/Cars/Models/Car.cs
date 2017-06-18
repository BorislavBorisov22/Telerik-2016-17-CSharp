using Newtonsoft.Json;
using System.Text;

namespace Cars.models
{
    public class Car
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public Dealer Dealer { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Year: {Year}, Model: {Model}, TransmissionType: {TransmissionType}" +
                $" Manufacturer: {Manufacturer}, Price: {Price}, Dealer: {Dealer}");

            return result.ToString();
        }
    }
}
