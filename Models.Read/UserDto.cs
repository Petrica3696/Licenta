using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Read
{
    public class UserDto : BaseModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
