using BusinessLogic.Read.Abstractions.Logics;
using BusinessLogic.Read.Abstractions.QueryBuilders;
using DataAccess.Read.Abstractions;
using Models.Read;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Implementations.Logics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserQueryBuilder _queryBuilder;

        private readonly IRepository _repository;

        public UserLogic(IUserQueryBuilder queryBuilder, IRepository repository)
        {
            _queryBuilder = queryBuilder;
            _repository = repository;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var query = _queryBuilder.BuildGetQuery();
            return _repository.ExecuteQuery<UserDto>(query);
        }

        public UserDto GetByUsername(string username)
        {
            var query = _queryBuilder.BuildGetByUsernameQuery(username);
            return _repository.ExecuteQueryFirstOrDefault<UserDto>(query);
        }
    }
}
