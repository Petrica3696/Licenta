using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface IProductLogic
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto GetByCategoryId(Guid id);
    }
}
