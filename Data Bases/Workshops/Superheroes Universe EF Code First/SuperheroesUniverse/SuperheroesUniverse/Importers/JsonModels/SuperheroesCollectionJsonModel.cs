using Newtonsoft.Json;
using SuperheroesUniverse.ImportModels;
using System.Collections.Generic;

namespace SuperheroesUniverse.Importers.JsonModels
{
    public class SuperheroesCollectionJsonModel
    {
        [JsonProperty("data")]
        public IEnumerable<SuperheroJsonModel> Superheroes { get; set; }
    }
}
