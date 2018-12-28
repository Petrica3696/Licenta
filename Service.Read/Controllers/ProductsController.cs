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
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return _productLogic.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetByCategoryId([FromRoute] Guid id)
        {
            var response = _productLogic.GetByCategoryId(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}