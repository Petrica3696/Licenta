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

            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = product.CategoryId,
                Username = product.Username,
                WinnerId = null,
                Name = product.Name,
                Description = product.Description,
                StartPrice = product.StartPrice,
                FinalPrice = null,
                Deadline = product.Deadline,
                IsSold = false,
                ImageFile = product.ImageFile
            };

            _repository.Insert(newProduct);
            _repository.Save();
        }

        public void CreateComment(CommentDto commentDto)
        {
            var newComment = new Comments
            {
                Id = Guid.NewGuid(),
                ProductId = commentDto.ProductId,
                UserId = commentDto.UserId,
                Text = commentDto.Text,
                PostDate = DateTime.Now
            };

            _repository.Insert(newComment);
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

        public void Update(Guid id, UpdateProductDto product)
        {
            Product productToUpdate = _repository.GetByFilter<Product>(p => p.Id == id);

            if (productToUpdate == null)
            {
                return;
            }

            if (product.CategoryId != null) { productToUpdate.CategoryId = product.CategoryId; }
            if (product.Name != null) { productToUpdate.Name = product.Name; }
            if (product.Description != null) { productToUpdate.Description = product.Description; }
            if (product.StartPrice != 0 && productToUpdate.FinalPrice == null) { productToUpdate.StartPrice = product.StartPrice; }
            if(product.Deadline > DateTime.Now) { productToUpdate.Deadline = product.Deadline; }


            _repository.Update(productToUpdate);
            _repository.Save();
        }

        public void UpdateBid(Guid id, UpdateBid product)
        {
            Product productToUpdate = _repository.GetByFilter<Product>(p => p.Id == id);

            if (productToUpdate == null)
            {
                return;
            }

            productToUpdate.FinalPrice = product.FinalPrice;
            productToUpdate.WinnerId = product.WinnerId;
            if(product.Deadline >= DateTime.Today) { productToUpdate.Deadline = product.Deadline; }

            _repository.Update(productToUpdate);
            _repository.Save();

            Wishlist wishlist = _repository.GetByFilter<Wishlist>(p => p.ProductId == id.ToString() && p.UserId == product.WinnerId);

            if(wishlist == null)
            {
                var newWish = new Wishlist
                {
                    Id = Guid.NewGuid(),
                    UserId = product.WinnerId,
                    ProductId = id.ToString()
                };

                _repository.Insert(newWish);
                _repository.Save();
            }


            Recommendations recommendations = _repository.GetByFilter<Recommendations>(p => p.UserId == product.WinnerId && p.CategoryId == productToUpdate.CategoryId);

            if(recommendations == null)
            {
                var newBid = new Recommendations
                {
                    Id = Guid.NewGuid(),
                    CategoryId = productToUpdate.CategoryId,
                    UserId = product.WinnerId,
                    Bids = 0
                };

                _repository.Insert(newBid);
                _repository.Save();
            }
            else
            {
                recommendations.Bids++;

                _repository.Update(recommendations);
                _repository.Save();
            }

            
        }
    }
}
