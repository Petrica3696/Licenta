using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface IProductLogic
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto GetProduct(Guid id);

        IEnumerable<ProductDto> GetByCategoryId(string id);

        IEnumerable<ProductDto> GetByUsername(string username);
    }
}
