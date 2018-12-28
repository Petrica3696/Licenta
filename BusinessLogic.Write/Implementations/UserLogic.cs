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

            var updatedUser = new User
            {
                Id = userToUpdate.Id,
                FirstName = (user.FirstName != null) ? user.FirstName : userToUpdate.FirstName,
                LastName = (user.LastName != null) ? user.LastName : userToUpdate.LastName,
                Username = (user.Username != null) ? user.Username : userToUpdate.Username,
                Password = (user.Password != null) ? user.Password : userToUpdate.Password
            };

            _repository.Update(updatedUser);
            _repository.Save();
        }
    }
}
