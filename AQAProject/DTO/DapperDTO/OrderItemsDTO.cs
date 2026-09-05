using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record OrderItemsDTO
        (
        long id,

        long orderId,

        long productId,

        long quantity,

        double unitPrice
        );
}
