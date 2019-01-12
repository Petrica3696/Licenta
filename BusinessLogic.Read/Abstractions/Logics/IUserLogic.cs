using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface IUserLogic
    {
        IEnumerable<UserDto> GetAll();

        UserDto GetById(string id);

        UserDto GetByUsernameAndPassword(string username, string password);

        UserDto Authenticate(string username, string password);
    }
}
