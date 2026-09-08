using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.BookStoreDTO
{
    public record UserResponseDTO
    (
         string UserId,
         string Username,
         IReadOnlyList<BookDTO> Books
    );
}
