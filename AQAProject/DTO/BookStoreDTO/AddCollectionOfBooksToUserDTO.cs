using System;
using System.Collections.Generic;
using System.Text;

namespace AQAProject.DTO.BookStoreDTO
{
    public record AddCollectionOfBooksToUserDTO
    (
        string userId,
        List<CollectionOfIsbnsDTO> collectionOfIsbns
    );
}
