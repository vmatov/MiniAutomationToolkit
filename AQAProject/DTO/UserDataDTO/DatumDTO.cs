using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UserDataDTO
{
    public record Datum(
            [property: JsonProperty("id")]
        [property: JsonPropertyName("id")] int id,
            [property: JsonProperty("username")]
        [property: JsonPropertyName("username")] string username,
            [property: JsonProperty("profile")]
        [property: JsonPropertyName("profile")] Profile profile,
            [property: JsonProperty("roles")]
        [property: JsonPropertyName("roles")] IReadOnlyList<string> roles
        );
}
