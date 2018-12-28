using Entities;
using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Abstractions
{
    public interface IProductLogic
    {
        Product GetByFilter(string name);

        void Create(ProductDto product);

        void Update(Guid id, ProductDto product);

        void Delete(Guid id);
    }
}
