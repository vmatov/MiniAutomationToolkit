using System;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UsersDTO;

public class CreateUserRequestDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("job")]
    public string Job { get; set; }
    
}