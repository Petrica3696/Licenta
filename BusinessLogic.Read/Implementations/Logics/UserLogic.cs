using BusinessLogic.Read.Abstractions.Logics;
using BusinessLogic.Read.Abstractions.QueryBuilders;
using DataAccess.Read.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Read;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic.Read.Implementations.Logics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserQueryBuilder _queryBuilder;

        private readonly IRepository _repository;

        private readonly AppSettings _appSettings;

        public UserLogic(IUserQueryBuilder queryBuilder, IRepository repository, IOptions<AppSettings> appSettings)
        {
            _queryBuilder = queryBuilder;
            _repository = repository;
            _appSettings = appSettings.Value;
        }


        public UserDto Authenticate(string username, string password)
        {
            var query = _queryBuilder.BuildGetByUsernameAndPasswordQuery(username, password);
            var user =_repository.ExecuteQueryFirstOrDefault<UserDto>(query);

            if (user == null)
                return null;

            //auth successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }


        public IEnumerable<UserDto> GetAll()
        {
            var query = _queryBuilder.BuildGetQuery();
            return _repository.ExecuteQuery<UserDto>(query);
        }

        public UserDto GetById(string id)
        {
            var query = _queryBuilder.BuildGetByIdQuery(id);
            return _repository.ExecuteQueryFirstOrDefault<UserDto>(query);
        }

        public UserDto GetByUsernameAndPassword(string username, string password)
        {
            var query = _queryBuilder.BuildGetByUsernameAndPasswordQuery(username, password);
            return _repository.ExecuteQueryFirstOrDefault<UserDto>(query);
        }

        public UserDto GetByUsername(string username)
        {
            var query = _queryBuilder.BuildGetByUsernameQuery(username);
            return _repository.ExecuteQueryFirstOrDefault<UserDto>(query);
        }
    }
}
