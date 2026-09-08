using AQAProject.DTO.PetsDTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.Interfaces.Pets
{
    public interface IPetAPI
    {
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsAsync();
        [Get("/pets/{id}")]
        Task<PetDTO> GetPetByIdAsync(string id);
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsFilteredByAgeMinAndLimitedAsync([Query] int ageMin, [Query] int limit);
    }
}
