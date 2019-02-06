using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.QueryBuilders
{
    public interface IProductQueryBuilder
    {
        string BuildGetQuery(string username);

        string BuildGetRecommendationsQuery(Guid id);

        string BuildGetCommentsQuery(Guid id);

        string BuildGetWishlistQuery(Guid id);

        string BuildGetProduct(Guid id);

        string BuildGetByCategoryIdQuery(string id);

        string BuildGetByUsernameQuery(string username);

        string BuildGetAllProducts();
    }
}
