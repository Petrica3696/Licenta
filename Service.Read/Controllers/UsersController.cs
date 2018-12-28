using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Read.Abstractions.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Read;
using Microsoft.Extensions.Configuration;

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

        // GET api/users
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _userLogic.GetAll();
        }

        [HttpGet("{username}")]
        public IActionResult GetByUserName([FromRoute] string username)
        {
            var response = _userLogic.GetByUsername(username);
            if( response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}