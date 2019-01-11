using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Read.Abstractions.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Read;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Service.Read.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _userLogic.GetAll();
        }

        //[HttpGet("{username}")]
        //public IActionResult GetByUserName([FromRoute] string username)
        //{
        //    var response = _userLogic.GetByUsername(username);
        //    if( response == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(response);
        //}

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userParam)
        {
            var user = _userLogic.Authenticate(userParam.Username, userParam.Password);

            if(user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}