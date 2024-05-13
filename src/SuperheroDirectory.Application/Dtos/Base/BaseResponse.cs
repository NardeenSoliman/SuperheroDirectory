using System.Text.Json.Serialization;

namespace SuperheroDirectory.Application.Dtos.Base
{
    public class BaseResponse
    {
        [JsonPropertyOrder(0)]
        public string Response { get; set; }

    }
}
