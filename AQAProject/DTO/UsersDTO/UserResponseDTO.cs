using System;
using System.Text.Json.Serialization;

namespace AQAProject.DTO.UsersDTO;

public class UserResponseDTO
{
    [JsonPropertyName("data")]
    public UserDataDTO Data { get; set; }
}