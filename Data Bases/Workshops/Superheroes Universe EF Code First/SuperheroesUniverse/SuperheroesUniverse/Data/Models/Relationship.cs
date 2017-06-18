using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Models
{
    public class Relationship
    {
        public int Id { get; set; }

        public RelationshipType RelationshipType { get; set; }

        public virtual Superhero FirstHero { get; set; }

        public virtual Superhero SecondHero { get; set; }
    }
}
