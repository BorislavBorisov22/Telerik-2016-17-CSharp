using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Data.Repository.Contracts;
using SuperheroesUniverse.Exporters.Contracts;
using SuperheroesUniverse.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml;

namespace SuperheroesUniverse.Exporters
{
    public class SuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private readonly IRepository<Superhero> heroesRepository;
        private readonly IRepository<Fraction> fractionsRepository;
        private readonly string filePath;

        public SuperheroesUniverseExporter(DbContext context, string filePath)
        {
            this.heroesRepository = new EfRepository<Superhero>(context);
            this.fractionsRepository = new EfRepository<Fraction>(context);
            this.filePath = filePath;
        }

        public string ExportAllSuperheroes()
        {
            var heroes = this.heroesRepository.All(x => true);
            this.ExportHeroes(heroes);

            return this.GetXmlString();
        }

        public string ExportFractionDetails(object fractionId)
        {
            var targetFraction = this.fractionsRepository.All(x => x.Id == (int)fractionId).FirstOrDefault();
            this.ExportFractionDetails(targetFraction);
            return this.GetXmlString();
        }

        public string ExportFractions()
        {
            var fractions = this.fractionsRepository.All(x => true);

            this.ExportFractions(fractions);

            return this.GetXmlString();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var targetHero = this.heroesRepository.All(x => x.Id == (int)superheroId).FirstOrDefault();
            this.ExportHeroDetails(targetHero);

            return this.GetXmlString();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var heroes = this.heroesRepository.All(x => x.City.Name == cityName);
            this.ExportHeroes(heroes);

            return this.GetXmlString();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var heroes = this.heroesRepository.All(x => x.Powers.Any(p => p.Name == power));
            this.ExportHeroes(heroes);

            return this.GetXmlString();
        }

        private string GetXmlString()
        {
            return File.ReadAllText(this.filePath);
        }

        private void ExportFractionDetails(Fraction fraction)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("fraction");
                xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                xmlWriter.WriteAttributeString("members", fraction.Members.Count.ToString());

                xmlWriter.WriteStartElement("planets");

                foreach (var planet in fraction.Planets)
                {
                    xmlWriter.WriteElementString("planet", planet.Name);
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("members");
                foreach (var member in fraction.Members)
                {
                    xmlWriter.WriteStartElement("member");
                    xmlWriter.WriteAttributeString("id", member.Id.ToString());
                    xmlWriter.WriteString(member.Name);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();

            }
        }

        private void ExportFractions(IEnumerable<Fraction> fractions)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("fractions");
                foreach (var fraction in fractions)
                {
                    xmlWriter.WriteStartElement("fraction");
                    xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                    xmlWriter.WriteAttributeString("members", fraction.Members.Count.ToString());

                    xmlWriter.WriteElementString("name", fraction.Name);
                    xmlWriter.WriteStartElement("planets");

                    foreach (var planet in fraction.Planets)
                    {
                        xmlWriter.WriteElementString("planet", planet.Name);
                    }

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }

        private void ExportHeroDetails(Superhero hero)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartElement("superhero");

                xmlWriter.WriteAttributeString("id", hero.Id.ToString());
                xmlWriter.WriteElementString("name", hero.Name);
                xmlWriter.WriteElementString("secretIdentity", hero.SecretIdentity);
                xmlWriter.WriteElementString("alignment", hero.Alignment.ToString());
                xmlWriter.WriteStartElement("powers");
                foreach (var power in hero.Powers)
                {
                    xmlWriter.WriteElementString("power", power.Name);
                }

                xmlWriter.WriteStartElement("fractions");
                foreach (var fraction in hero.Fractions)
                {
                    xmlWriter.WriteStartElement("fraction");
                    xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                    xmlWriter.WriteString(fraction.Name);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();

                xmlWriter.WriteElementString("city", $"{hero.City.Name}, {hero.City.Country.Name}, {hero.City.Country.Planet.Name}");
                xmlWriter.WriteElementString("story", hero.Story);

                xmlWriter.WriteEndElement();
            }
        }

        private void ExportHeroes(IEnumerable<Superhero> heroes)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("superheroes");

                foreach (var hero in heroes)
                {
                    xmlWriter.WriteStartElement("superhero");

                    xmlWriter.WriteAttributeString("id", hero.Id.ToString());
                    xmlWriter.WriteElementString("name", hero.Name);
                    xmlWriter.WriteElementString("secretIdentity", hero.SecretIdentity);
                    xmlWriter.WriteElementString("alignment", hero.Alignment.ToString());
                    xmlWriter.WriteStartElement("powers");
                    foreach (var power in hero.Powers)
                    {
                        xmlWriter.WriteElementString("power", power.Name);
                    }

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteElementString("city", $"{hero.City.Name}, {hero.City.Country.Name}, {hero.City.Country.Planet.Name}");

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }
    }
}
