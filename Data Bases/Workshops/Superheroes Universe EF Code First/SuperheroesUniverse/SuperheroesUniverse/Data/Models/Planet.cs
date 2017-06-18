using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Planet
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}