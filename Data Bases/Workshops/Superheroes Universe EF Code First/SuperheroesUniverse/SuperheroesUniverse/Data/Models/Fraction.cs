using SuperheroesUniverse.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        public Fraction()
        {
            this.Planets = new HashSet<Planet>();
            this.Members = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public Alignment Alignment { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Superhero> Members { get; set; }
    }
}
