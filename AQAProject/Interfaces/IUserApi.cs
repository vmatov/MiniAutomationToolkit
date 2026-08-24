using System;
using System.Collections.Generic;
using System.Text;
using AQAProject.DTO.UsersDTO;
using Refit;

namespace AQAProject.Interfaces
{
    [Headers("x-api-key: free_user_3I3Q38F2JDCzaphi3n13THU5zc4")]

    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Put("/users/{id}")]
        Task<CreateUserResponseDTO> UpdateUserAsync(int id, [Body] CreateUserRequestDTO request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}
