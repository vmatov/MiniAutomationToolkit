using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UserDataDTO
{
    public record Profile(
        [property: JsonProperty("fullName")]
        [property: JsonPropertyName("fullName")] string fullName,
        [property: JsonProperty("age")]
        [property: JsonPropertyName("age")] int age,
        [property: JsonProperty("address")]
        [property: JsonPropertyName("address")] Address address,
        [property: JsonProperty("tags")]
        [property: JsonPropertyName("tags")] IReadOnlyList<string> tags
    );
}
