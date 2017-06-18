using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Models;
using System.Data.Entity;

namespace SuperheroesUniverse.Data.Context
{
    public class SuperHeroesDbContext : DbContext
    {
        private const string ConnectionStringName = "SuperheroesDb";

        public SuperHeroesDbContext() 
            : base(ConnectionStringName)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SuperHeroesDbContext>());
        }

        public virtual IDbSet<Superhero> Superheroes { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<City> Cities { get; set; }
        
        public virtual IDbSet<Relationship> Relationships { get; set; }

        public virtual IDbSet<Power> Powers { get; set; }
    }
}