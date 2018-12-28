using BusinessLogic.Read.Abstractions.Logics;
using BusinessLogic.Read.Abstractions.QueryBuilders;
using DataAccess.Read.Abstractions;
using Models.Read;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.Logics
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryQueryBuilder _queryBuilder;

        private readonly IRepository _repository;

        public CategoryLogic(ICategoryQueryBuilder queryBuilder, IRepository repository)
        {
            _queryBuilder = queryBuilder;
            _repository = repository;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var query = _queryBuilder.BuildGetQuery();
            return _repository.ExecuteQuery<CategoryDto>(query);
        }

        public CategoryDto GetByCategoryName(string categoryName)
        {
            var query = _queryBuilder.BuildGetByCategoryNameQuery(categoryName);

            return _repository.ExecuteQueryFirstOrDefault<CategoryDto>(query);
        }
    }
}
