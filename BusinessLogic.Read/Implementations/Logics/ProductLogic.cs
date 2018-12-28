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

        public IEnumerable<ProductDto> GetAll()
        {
            var query = _queryBuilder.BuildGetQuery();
            return _repository.ExecuteQuery<ProductDto>(query);
        }

        public ProductDto GetByCategoryId(Guid id)
        {
            var query = _queryBuilder.BuildGetByCategoryIdQuery(id);
            return _repository.ExecuteQueryFirstOrDefault<ProductDto>(query);
        }
    }
}
