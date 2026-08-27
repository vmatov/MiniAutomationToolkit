using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace AQAProject.DTO.UserDataDTO
{
    public record Geo(
        [property: JsonProperty("lat")]
        [property: JsonPropertyName("lat")] double lat,
        [property: JsonProperty("lng")]
        [property: JsonPropertyName("lng")] double lng
    );
}