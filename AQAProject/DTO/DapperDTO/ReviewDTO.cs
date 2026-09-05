using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record ReviewDTO
        (
        long id,

        string userId,

        string productId,

        long rating,

        long comment,

        long createdAt
        );
}
