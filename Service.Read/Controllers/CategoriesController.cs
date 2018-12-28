using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Read.Abstractions.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Read;

namespace Service.Read.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoriesController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        //GET api/categories
        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            return _categoryLogic.GetAll();
        }
        [HttpGet("categories")]
        public IActionResult GetByCategoryName([FromRoute] string name)
        {
            var response = _categoryLogic.GetByCategoryName(name);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}