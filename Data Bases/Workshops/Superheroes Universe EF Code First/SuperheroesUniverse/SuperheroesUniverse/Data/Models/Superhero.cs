using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        public Superhero()
        {
            this.Fractions = new HashSet<Fraction>();
            this.Powers = new HashSet<Power>();
        }

        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        public string SecretIdentity { get; set; }

        [Required]
        public Alignment Alignment { get; set; }

        [Required]
        public string Story { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Fraction> Fractions { get; set; }

        public virtual ICollection<Power> Powers { get; set; }
    }
}
