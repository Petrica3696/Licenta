using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Abstractions
{
    public interface ICategoryLogic
    {
        void Create(CategoryDto category);
    }
}
