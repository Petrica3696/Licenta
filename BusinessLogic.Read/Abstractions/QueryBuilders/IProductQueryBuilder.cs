using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.QueryBuilders
{
    public interface IProductQueryBuilder
    {
        string BuildGetQuery();

        string BuildGetByCategoryIdQuery(Guid id);
    }
}
