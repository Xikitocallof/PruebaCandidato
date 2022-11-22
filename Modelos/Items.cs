using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PruebasCandidatos.Modelos
{
    public class ItemsJSON
    {
        [JsonPropertyName ("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Children")]
        public List<Children>? Children { get; set; }
    }
    public class Items
    {
        [JsonProperty("Value")]
        public string Name { get; set; }
        public List<Children> Children { get; set; }
    }

    public class Children
    {
        public string Name { get; set; }
        [JsonProperty ("Children")]
        public List<Children> Children_2 { get; set; }
    }
}
