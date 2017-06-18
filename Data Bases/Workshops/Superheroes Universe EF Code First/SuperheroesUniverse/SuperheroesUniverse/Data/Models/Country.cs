namespace SuperheroesUniverse.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Planet Planet { get; set; }
    }
}