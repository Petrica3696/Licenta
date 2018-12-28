using BusinessLogic.Read.Abstractions.QueryBuilders;
using BusinessLogic.Read.Common.QueryBuilder.Implementations;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.QueryBuilders
{
    public class CategoryQueryBuilder : ICategoryQueryBuilder
    {
        public string BuildGetQuery()
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Categories");
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

        public string BuildGetByCategoryNameQuery(string categoryName)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Products");
            queryBuilder.AddWhere("Name", Comparison.Equals, categoryName);
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }
    }
}
