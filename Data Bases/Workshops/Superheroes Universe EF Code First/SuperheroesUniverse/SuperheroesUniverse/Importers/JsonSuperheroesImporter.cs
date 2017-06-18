using Newtonsoft.Json;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Data.Repository.Contracts;
using SuperheroesUniverse.Importers.Contracts;
using SuperheroesUniverse.Importers.JsonModels;
using SuperheroesUniverse.ImportModels;
using SuperheroesUniverse.Models;
using SuperheroesUniverse.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace SuperheroesUniverse.Importers
{
    public class JsonSuperheroesImporter : ISuperheroesImporter
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepository<Superhero> superHeroes;
        private readonly IRepository<Power> powers;
        private readonly IRepository<City> cities;
        private readonly IRepository<Country> countries;
        private readonly IRepository<Planet> planets;
        private readonly IRepository<Fraction> fractions;

        public JsonSuperheroesImporter(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context cannot be null!");
            }

            this.unitOfWork = new UnitOfWork(context);
            this.superHeroes = new EfRepository<Superhero>(context);
            this.powers = new EfRepository<Power>(context);
            this.cities = new EfRepository<City>(context);
            this.countries = new EfRepository<Country>(context);
            this.planets = new EfRepository<Planet>(context);
            this.fractions = new EfRepository<Fraction>(context);
        }

        public void LoadSuperHeroes(string filePath)
        {
            var superHeores = new List<Superhero>();

            string json = File.ReadAllText(filePath);

            var jsonSuperheroesCollection = JsonConvert.DeserializeObject<SuperheroesCollectionJsonModel>(json);
            this.AddHeroesToDatabase(jsonSuperheroesCollection.Superheroes);
        }

        private void AddHeroesToDatabase(IEnumerable<SuperheroJsonModel> superheores)
        {
            foreach (var heroJsonModel in superheores)
            {
                if (this.superHeroes.All(x => x.Name == heroJsonModel.Name).FirstOrDefault() != null)
                {
                    continue;
                }

                var heroToAdd = new Superhero();

                // add name to hero
                var heroName = heroJsonModel.Name;
                heroToAdd.Name = heroName;

                // secret identity
                heroToAdd.SecretIdentity = heroJsonModel.SecretIdentity;

                // add hero alignment
                Alignment heroAlignment;
                string alignmentString = char.ToUpper(heroJsonModel.Alignment[0]) + heroJsonModel.Alignment.Substring(1).ToLower();
                Enum.TryParse<Alignment>(alignmentString, out heroAlignment);
                heroToAdd.Alignment = heroAlignment;

                // planet of superhero
                var planetJsonModel = heroJsonModel.City.Planet;
                var planetToAdd = this.planets.All(x => x.Name == planetJsonModel).FirstOrDefault();
                if (planetToAdd == null)
                {
                    planetToAdd = new Planet() { Name = planetJsonModel };
                }

                // country of superhero
                var countryJsonModel = heroJsonModel.City.Country;
                var countryToAdd = this.countries.All(x => x.Name == countryJsonModel).FirstOrDefault();
                if (countryToAdd == null)
                {
                    countryToAdd = new Country() { Name = countryJsonModel, Planet = planetToAdd };
                }

                // city of superhero
                var cityJsonModel = heroJsonModel.City.Name;
                var cityToAdd = this.cities.All(x => x.Name == cityJsonModel).FirstOrDefault();
                if (cityToAdd == null)
                {
                    cityToAdd = new City() { Name = cityJsonModel, Country = countryToAdd };
                }

                heroToAdd.City = cityToAdd;

                // superhero story
                heroToAdd.Story = heroJsonModel.Story;

                // fractions
                foreach (var fractionName in heroJsonModel.Fractions)
                {
                    var targetFraction = this.fractions.All(x => x.Name == fractionName).FirstOrDefault();
                    if (targetFraction == null)
                    {
                        targetFraction = new Fraction()
                        {
                            Name = fractionName,
                        };

                        targetFraction.Planets.Add(planetToAdd);
                        this.fractions.Add(targetFraction);
                    }

                    targetFraction.Members.Add(heroToAdd);
                }
                // powers
                foreach (var powerName in heroJsonModel.Powers)
                {
                    var targetPower = this.powers.All(x => x.Name == powerName).FirstOrDefault();
                    if (targetPower == null)
                    {
                        targetPower = new Power() { Name = powerName };
                    }

                    heroToAdd.Powers.Add(targetPower);
                }

                this.superHeroes.Add(heroToAdd);

                this.unitOfWork.SaveChanges();
            }   
        }
    }
}