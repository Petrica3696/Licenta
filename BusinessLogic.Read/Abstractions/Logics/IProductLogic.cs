using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface IProductLogic
    {
        IEnumerable<ProductDto> GetAll(string username);

        IEnumerable<ProductDto> GetRecommendations(Guid id);

        IEnumerable<CommentsDto> GetComments(Guid id);

        IEnumerable<ProductDto> GetWishlist(Guid id);

        ProductDto GetProduct(Guid id);

        IEnumerable<ProductDto> GetByCategoryId(string id);

        IEnumerable<ProductDto> GetByUsername(string username);
    }
}
