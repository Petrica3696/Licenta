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
        public IEnumerable<ProductDto> GetAll()
        {
            return _productLogic.GetAll();
        }

        //GET api/products/recommendations
        [HttpGet("recommendations/{id}")]
        public IEnumerable<ProductDto> GetRecommendations([FromRoute] Guid id)
        {
            return _productLogic.GetRecommendations(id);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct([FromRoute] Guid id)
        {
            var response = _productLogic.GetProduct(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("my-products/{username}")]
        public IEnumerable<ProductDto> GetByUsername([FromRoute] string username)
        {
            var response = _productLogic.GetByUsername(username);
            return response;
        }

        //[HttpGet("{categoryId}")]
        //public IEnumerable<ProductDto> GetByCategoryId([FromRoute] string categoryId)
        //{
        //    var response = _productLogic.GetByCategoryId(categoryId);
        //    return response;
        //}
    }
}