using BusinessLogic.Write.Abstractions;
using DataAccess.Write.Abstractions;
using Entities;
using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Implementations
{
    public class ProductLogic : IProductLogic
    {
        private readonly IRepository _repository;

        public ProductLogic(IRepository repository)
        {
            _repository = repository;
        }

        public void Create(ProductDto product)
        {
            var author = _repository.GetByFilter<User>(a => a.Username == product.AuthorUsername);

            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = product.CategoryId,
                Username = author.Username,
                WinnerId = product.WinnerId,
                Name = product.Name,
                Description = product.Description,
                StartPrice = product.StartPrice,
                FinalPrice = product.FinalPrice,
                Deadline = product.Deadline,
                IsSold = product.IsSold
            };

            _repository.Insert(newProduct);
            _repository.Save();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product GetByFilter(string name)
        {
            return _repository.GetByFilter<Product>((p) => p.Name == name);
        }

        public void Update(Guid id, ProductDto product)
        {
            var productToUpdate = _repository.GetByFilter<Product>(p => p.Id == id);

            if (productToUpdate == null)
            {
                return;
            }

            var updatedProduct = new Product
            {
                Id = productToUpdate.Id,
                Name = (product.Name != null) ? product.Name : productToUpdate.Name,
                Username = productToUpdate.Username,
                CategoryId = productToUpdate.CategoryId,
                Description = (product.Description != null) ? product.Description : productToUpdate.Description,
                StartPrice = (product.StartPrice != 0) ? product.StartPrice : productToUpdate.StartPrice,
                FinalPrice = (product.FinalPrice != 0) ? product.FinalPrice : productToUpdate.FinalPrice,
                IsSold = (product.IsSold != true) ? true : false
            };

            _repository.Update(updatedProduct);
            _repository.Save();
        }
    }
}
