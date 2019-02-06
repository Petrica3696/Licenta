using System.Collections.Generic;
using BusinessLogic.Read.Abstractions.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Read;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Service.Read.Controllers
{
    [ApiController]
    [Route("api/users")]
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

        [HttpGet("{username}")]
        public IActionResult GetByUserName([FromRoute] string username)
        {
            var response = _userLogic.GetByUsername(username);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var response = _userLogic.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


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

        [HttpGet("current")]
        public ActionResult<UserDto> Get()
        {
            var currentUserId = HttpContext.User.Identity.Name;

            var user = _userLogic.GetById(currentUserId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}