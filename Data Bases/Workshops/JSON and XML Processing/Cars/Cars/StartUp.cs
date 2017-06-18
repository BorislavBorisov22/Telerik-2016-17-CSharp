using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System;
using System.Collections.Generic;
using Cars.models;
using Cars.Models.JsonModels;
using Cars.Providers;

namespace Cars
{
    public class StartUp
    {
        public static void Main()
        {
            string jsonFilePath = "../../data.number.json";
            string carsJson = File.ReadAllText(jsonFilePath);

            var jsonModelCars = JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(carsJson);
            IEnumerable<Car> cars = jsonModelCars.Select(CarJsonModel.FormJsonModel);

            var xmlProvider = new XmlProvider();
            string xmlQueryPath = "../../queries.xml";
            var xmlQuery = xmlProvider.GetXmlQuery(xmlQueryPath);

            var filteredCars = xmlProvider.ProcessQueries(xmlQuery, cars);

            string outputFilePath = "../../output.xml";
            xmlProvider.SaveCarsToXML(filteredCars, outputFilePath);
        }
    }
}
