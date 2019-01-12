using BusinessLogic.Read.Abstractions.QueryBuilders;
using BusinessLogic.Read.Common.QueryBuilder.Implementations;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.QueryBuilders
{
    public class UserQueryBuilder : IUserQueryBuilder
    {
        public string BuildGetQuery()
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Users");
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

        public string BuildGetByIdQuery(string id)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Users");
            queryBuilder.AddWhere("Id", Comparison.Equals, id);
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

        public string BuildGetByUsernameAndPasswordQuery(string username, string password)
        {
            var queryBuilder = new SelectQueryBuilder();

            queryBuilder.SelectFromTable("Users");
            queryBuilder.AddWhere("Username", Comparison.Equals, username);
            queryBuilder.AddWhere("Password", Comparison.Equals, password);
            queryBuilder.BuildQuery();

            return queryBuilder.BuildQuery();
        }

    }
}
