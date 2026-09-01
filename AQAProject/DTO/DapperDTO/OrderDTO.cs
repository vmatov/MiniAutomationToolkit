using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record OrderDTO
        (
        long id,

        long userId,

        string orderDate,

        string status,

        double totalPrice
        );
}
