using BusinessLogic.Read.Abstractions.QueryBuilders;
using BusinessLogic.Read.Common.QueryBuilder.Implementations;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.QueryBuilders
{
    public class ProductQueryBuilder : IProductQueryBuilder
    {
        public string BuildGetQuery(string username)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddWhere("Username", Comparison.NotEquals, username);
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

        public string BuildGetRecommendationsQuery(Guid id)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Recommendations");
            queryBuilder.SelectColumn("Recommendations.CategoryId");
            queryBuilder.AddWhere("UserId", Comparison.Equals, id.ToString());
            queryBuilder.AddOrderBy("Bids", Sorting.Descending);
            queryBuilder.TopRecords = 1;

            return queryBuilder.BuildQuery();
        }

        public string BuildGetWishlistQuery(Guid id)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddJoin(JoinType.InnerJoin, "Wishlist", "ProductId", Comparison.Equals, "Products", "Id");
            queryBuilder.AddWhere("Wishlist.UserId", Comparison.Equals, id.ToString());

            return queryBuilder.BuildQuery();
        }

        public string BuildGetProduct(Guid id)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddWhere("Id", Comparison.Equals, id.ToString());
            queryBuilder.BuildQuery();


            return queryBuilder.BuildQuery();
        }

        public string BuildGetByCategoryIdQuery(string id)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddWhere("CategoryId", Comparison.Equals, id);
            queryBuilder.BuildQuery();


            return queryBuilder.BuildQuery();
        }

        public string BuildGetByUsernameQuery(string username)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddWhere("Username", Comparison.Equals, username );
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

        public string BuildGetAllProducts()
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }
    }
}
