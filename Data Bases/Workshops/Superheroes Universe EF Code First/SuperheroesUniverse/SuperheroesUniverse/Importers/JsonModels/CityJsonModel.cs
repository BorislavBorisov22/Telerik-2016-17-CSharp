using Newtonsoft.Json;

namespace SuperheroesUniverse.ImportModels
{
    public class CityJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("planet")]
        public string Planet { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
