using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.QueryBuilders
{
    public interface ICategoryQueryBuilder
    {
        string BuildGetQuery();

        string BuildGetByCategoryNameQuery(string categoryName);
    }
}
