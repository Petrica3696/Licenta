using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface ICategoryLogic
    {
        IEnumerable<CategoryDto> GetAll();

        CategoryDto GetByCategoryId(Guid id);
    }
}
