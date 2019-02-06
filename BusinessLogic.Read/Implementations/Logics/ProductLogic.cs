using BusinessLogic.Read.Abstractions.Logics;
using BusinessLogic.Read.Abstractions.QueryBuilders;
using DataAccess.Read.Abstractions;
using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.Logics
{
    public class ProductLogic : IProductLogic
    {
        public readonly IProductQueryBuilder _queryBuilder;

        private readonly IRepository _repository;

        public ProductLogic(IProductQueryBuilder queryBuilder, IRepository repository)
        {
            _queryBuilder = queryBuilder;
            _repository = repository;
        }

        public IEnumerable<ProductDto> GetAll(string username)
        {
            var query = _queryBuilder.BuildGetQuery(username);
            return _repository.ExecuteQuery<ProductDto>(query);
        }

        public IEnumerable<ProductDto> GetRecommendations(Guid id)
        {
            var categQuery = _queryBuilder.BuildGetRecommendationsQuery(id);

            if (_repository.ExecuteQuery<ProductDto>(categQuery).Count != 0) {

                var categId = _repository.ExecuteQuery<ProductDto>(categQuery)[0].CategoryId;
                var query = _queryBuilder.BuildGetByCategoryIdQuery(categId);

                return _repository.ExecuteQuery<ProductDto>(query);
            }
            else
            {
                var query = _queryBuilder.BuildGetAllProducts();
                return _repository.ExecuteQuery<ProductDto>(query);
            }         

        }

        public IEnumerable<ProductDto> GetWishlist(Guid id)
        {
            var query = _queryBuilder.BuildGetWishlistQuery(id);
            return _repository.ExecuteQuery<ProductDto>(query);
        }

        public ProductDto GetProduct(Guid id)
        {
            var query = _queryBuilder.BuildGetProduct(id);
            return _repository.ExecuteQueryFirstOrDefault<ProductDto>(query);
        }

        public IEnumerable<ProductDto> GetByCategoryId(string id)
        {
            var query = _queryBuilder.BuildGetByCategoryIdQuery(id);
            return _repository.ExecuteQuery<ProductDto>(query);
        }

        public IEnumerable<ProductDto> GetByUsername(string username)
        {
            var query = _queryBuilder.BuildGetByUsernameQuery(username);
            return _repository.ExecuteQuery<ProductDto>(query);
        }
    }
}
