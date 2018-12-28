using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.QueryBuilders
{
    public interface IUserQueryBuilder
    {
        string BuildGetByUsernameQuery(string username);

        string BuildGetQuery();
    }
}
