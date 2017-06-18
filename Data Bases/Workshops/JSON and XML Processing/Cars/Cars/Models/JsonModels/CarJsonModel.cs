using Cars.models;
using Cars.Data;
using System.Linq;
using Newtonsoft.Json;

namespace Cars.Models.JsonModels
{
    public class CarJsonModel
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        [JsonProperty("dealer")]
        public DealerJsonModel Dealer { get; set; }

        public static Car FormJsonModel(CarJsonModel jsonModel)
        {
            Dealer dealer = Data.Data.Dealers.FirstOrDefault(d => d.Name == jsonModel.Dealer.Name);

            if (dealer == null)
            {
                dealer = new Dealer { Name = jsonModel.Dealer.Name };
                Data.Data.Dealers.Add(dealer);
            }

            City city = Data.Data.Cities.FirstOrDefault(x => x.Name == jsonModel.Dealer.City);
            
            if (city == null)
            {
                city = new City { Name = jsonModel.Dealer.City };
                Data.Data.Cities.Add(city);
            }

            // make sure that car dealer has uniquie cities
            if (!dealer.Cities.Any(x => x.Name == city.Name))
            {
                dealer.Cities.Add(city);
            }

            var car = new Car
            {
                Model = jsonModel.Model,
                Dealer = dealer,
                Manufacturer = new Manufacturer { Name = jsonModel.ManufacturerName},
                Price = jsonModel.Price,
                TransmissionType = jsonModel.TransmissionType,
                Year = jsonModel.Year
            };

            return car;
        }
    }
}
