using System.Text.Json.Serialization;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class Biography
    {
        [JsonPropertyName("full-name")]
        public string FullName { set; get; }

        [JsonPropertyName("alter-egos")]
        public string AlterEgos { set; get; }

        public List<string> Aliases { set; get; }

        [JsonPropertyName("place-of-birth")]
        public string PlaceOfBirth { set; get; }

        [JsonPropertyName("first-appearance")]
        public string FirstAppearance { set; get; }

        public string Publisher { set; get; }

        public string Alignment { set; get; }
    }
}
