using System.Text.Json.Serialization;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class Appearance
    {
        public string Gender { set; get; }

        public string Race { set; get; }

        public List<string> Height { set; get; }

        public List<string> Weight { set; get; }

        [JsonPropertyName("eye-color")]
        public string EyeColor { set; get; }

        [JsonPropertyName("hair-color")]
        public string HairColor { set; get; }

    }
}
