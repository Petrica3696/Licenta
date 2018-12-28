using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Write;
using Microsoft.Extensions.Configuration;
using BusinessLogic.Write.Abstractions;

namespace Service.Read.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create([FromBody] UserDto user)
        {
            _userLogic.Create(user);

            return NoContent();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UserDto user)
        {
            _userLogic.Update(id, user);

            return NoContent();
        }
    }
}