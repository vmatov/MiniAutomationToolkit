using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.DapperDTO
{
    public record UserDTO
        (
        long id,

        string firstName,

        string lastName,

        string email,

        string phone,

        string createdAt
        );

 }