using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.BookStoreDTO
{
    public record DeleteBookResponseDTO
    (
        string Isbn,
        string UserId,
        string Message
    );
}
