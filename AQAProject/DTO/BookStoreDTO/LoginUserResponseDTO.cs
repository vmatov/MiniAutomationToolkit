using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.BookStoreDTO
{
    public record LoginUserResponseDTO
    (
        string UserId,

        string Username,

        string Password,

        string Token,

        string Expires,

        string Created_Date,

        bool IsActive
    );
}
