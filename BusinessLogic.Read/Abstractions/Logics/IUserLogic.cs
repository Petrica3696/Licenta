using Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Abstractions.Logics
{
    public interface IUserLogic
    {
        IEnumerable<UserDto> GetAll();

        UserDto GetByUsername(string username);
    }
}
