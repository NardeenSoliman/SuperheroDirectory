using System.Text.Json.Serialization;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class Connections
    {
        [JsonPropertyName("group-affiliation")]
        public string GroupAffiliation { set; get; }

        public string Relatives { set; get; }
    }
}
