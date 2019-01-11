using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.QueryBuilders
{
    public interface IUserQueryBuilder
    {
        string BuildGetByUsernameAndPasswordQuery(string username, string password);

        string BuildGetQuery();
    }
}
