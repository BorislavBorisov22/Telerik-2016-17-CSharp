using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
