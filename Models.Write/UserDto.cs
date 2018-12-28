using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
