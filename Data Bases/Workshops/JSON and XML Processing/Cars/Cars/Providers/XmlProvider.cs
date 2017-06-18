using Cars.models;
using Cars.Providers.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Cars.Providers
{
    public class XmlProvider
    {
        public XmlQuery GetXmlQuery(string xmlPath)
        {
            var xmlQuery = new XmlQuery();

            using (var xmlReader = XmlReader.Create(xmlPath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement() && xmlReader.Name == "OrderBy")
                    {
                        xmlReader.Read();
                        xmlQuery.Order = xmlReader.Value;
                    }
                    else if (xmlReader.IsStartElement() && xmlReader.Name == "WhereClause")
                    {
                        var whereClauseToAdd = new XmlWhereClause
                        {
                            PropertyName = xmlReader.GetAttribute("PropertyName"),
                            Type = xmlReader.GetAttribute("Type")
                        };

                        xmlReader.Read();
                        whereClauseToAdd.Value = xmlReader.Value;

                        xmlQuery.WhereClauses.Add(whereClauseToAdd);
                    }
                }
            }

            return xmlQuery;
        }

        public IEnumerable<Car> ProcessQueries(XmlQuery xmlQuery, IEnumerable<Car> cars)
        {
            foreach (var query in xmlQuery.WhereClauses)
            {
                string propName = query.PropertyName;

                if (propName == "Year")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Equals:
                            cars = cars.Where(c => c.Year == int.Parse(query.Value));
                            break;
                        case WhereType.GreaterThan:
                            cars = cars.Where(c => c.Year > int.Parse(query.Value));
                            break;
                        case WhereType.LessThan:
                            cars = cars.Where(c => c.Year < int.Parse(query.Value));
                            break;
                    }
                }
                else if (propName == "Price")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Equals:
                            cars = cars.Where(c => c.Price == decimal.Parse(query.Value));
                            break;
                        case WhereType.GreaterThan:
                            cars = cars.Where(c => c.Price > decimal.Parse(query.Value));
                            break;
                        case WhereType.LessThan:
                            cars = cars.Where(c => c.Price < decimal.Parse(query.Value));
                            break;
                    }
                }
                else if (propName == "Model")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Contains:
                            cars = cars.Where(c => c.Model.Contains(query.Value));
                            break;
                        case WhereType.Equals:
                            cars = cars.Where(c => c.Model == query.Value);
                            break;
                    }
                }
                else if (propName == "Manufacturer")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Contains:
                            cars = cars.Where(c => c.Manufacturer.Name.Contains(query.Value));
                            break;
                        case WhereType.Equals:
                            cars = cars.Where(c => c.Manufacturer.Name == query.Value);
                            break;
                    }
                }
                else if (propName == "City")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Contains:
                            cars = cars.Where(c => c.Dealer.Cities.Any(dc => dc.Name.Contains(query.Value)));
                            break;
                        case WhereType.Equals:
                            cars = cars.Where(c => c.Dealer.Cities.Any(dc => dc.Name == query.Value));
                            break;
                    }
                }
                else if (propName == "Dealer")
                {
                    switch (query.WhereType)
                    {
                        case WhereType.Contains:
                            cars = cars.Where(x => x.Dealer.Name.Contains(query.Value));
                            break;
                        case WhereType.Equals:
                            cars = cars.Where(x => x.Dealer.Name == query.Value);
                            break;
                    }
                }
            }

            return cars;
        }

        public void SaveCarsToXML(IEnumerable<Car> cars, string outputPath)
        {
            using(var xmlWriter = XmlWriter.Create(outputPath))
            {
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("cars");
                foreach (var car in cars)
                {
                    xmlWriter.WriteStartElement("Car");
                        xmlWriter.WriteAttributeString("Manufacturer", car.Manufacturer.Name);
                        xmlWriter.WriteAttributeString("Model", car.Model);
                        xmlWriter.WriteAttributeString("Year", car.Year.ToString());
                        xmlWriter.WriteAttributeString("Price", car.Price.ToString());
                        xmlWriter.WriteElementString("TransmissionType", car.TransmissionType.ToString());
                        xmlWriter.WriteStartElement("Dealer");
                            xmlWriter.WriteAttributeString("Name", car.Dealer.Name);
                            xmlWriter.WriteStartElement("Cities");
                                foreach(var city in car.Dealer.Cities)
                                {
                                    xmlWriter.WriteElementString("City", city.Name);
                                }
                           xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
            }
        }
    }
}
