using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UserDataDTO
{
    public record Address(
        [property: JsonProperty("street")]
        [property: JsonPropertyName("street")] string street,
        [property: JsonProperty("city")]
        [property: JsonPropertyName("city")] string city,
        [property: JsonProperty("geo")]
        [property: JsonPropertyName("geo")] Geo geo
    );
}
