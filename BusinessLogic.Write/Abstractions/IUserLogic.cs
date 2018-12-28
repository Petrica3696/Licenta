using Entities;
using Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Abstractions
{
    public interface IUserLogic
    {
        User GetByFilter(string username);

        void Create(UserDto user);

        void Update(Guid id, UserDto user);

        void Delete(Guid id);
    }
}
