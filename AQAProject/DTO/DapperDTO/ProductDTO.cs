using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record ProductDTO
        (
        long id,

        string name,

        string description,

        double price,

        long stock,

        long categoryId
        );
}
