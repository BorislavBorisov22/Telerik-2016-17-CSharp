using SuperheroesUniverse.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Data.Models
{
    public class Power
    {
        public int Id { get; set; }

        [MaxLength(35)]
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes { get; set; }
    }
}
