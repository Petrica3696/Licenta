﻿using System;

namespace Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public double? Rate { get; set; }

        public string Avatar { get; set; }
    }
}
