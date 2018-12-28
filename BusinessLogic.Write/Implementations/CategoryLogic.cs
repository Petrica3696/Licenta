using BusinessLogic.Write.Abstractions;
using Entities;
using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Implementations
{
    public class CategoryLogic : ICategoryLogic
    {
        public void Create(CategoryDto category)
        {
            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = category.Name
            };
        }
    }
}
