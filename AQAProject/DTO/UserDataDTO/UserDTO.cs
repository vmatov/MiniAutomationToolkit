using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UserDataDTO
{
    public record UserDTO(
            [property: JsonProperty("data")]
        [property: JsonPropertyName("data")] IReadOnlyList<Datum> data
        );
}
