using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.BookStoreDTO
{
    public record TokenUserResponseDTO(

        string Token,

        string Expires,

        string Status,

        string Result
    );
}
