using BusinessLogic.Write.Abstractions;
using DataAccess.Write.Abstractions;
using Entities;
using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Implementations
{
    public class UserLogic : IUserLogic
    {
        private readonly IRepository _repository;

        public UserLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }

        public void Create(UserDto user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password
            };

            _repository.Insert(newUser);
            _repository.Save();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetByFilter(string username)
        {
            return _repository.GetByFilter<User>((u) => u.Username == username);
        }

        public void Update(Guid id, UserDto user)
        {
            var userToUpdate = _repository.GetByFilter<User>(p => p.Id == id);

            if(userToUpdate == null)
            {
                return;
            }

            if (user.FirstName != null) userToUpdate.FirstName = user.FirstName;
            if (user.LastName != null) userToUpdate.LastName = user.LastName;
            if (user.Username != null) userToUpdate.Username = user.Username;
            if (user.Password != null) userToUpdate.Password = user.Password;

            _repository.Update(userToUpdate);
            _repository.Save();
        }
    }
}
