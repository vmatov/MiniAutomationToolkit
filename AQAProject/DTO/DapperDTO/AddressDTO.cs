using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record AddressDTO
        (
        long id,

        long userId,

        string city,

        string street,

        string house,

        string apartment
        );
}
