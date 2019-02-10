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
        [HttpGet("otherproducts/{username}")]
        public IEnumerable<ProductDto> GetAll([FromRoute] string username)
        {
            return _productLogic.GetAll(username);
        }

        //GET api/products/wishlist
        [HttpGet("wishlist/{id}")]
        public IEnumerable<ProductDto> GetWishlist([FromRoute] Guid id)
        {
            return _productLogic.GetWishlist(id);
        }

        //GET api/products/recommendations/UserId
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

        //GET api/products/comments/productId
        [HttpGet("comments/{id}")]
        public IEnumerable<CommentsDto> GetComments([FromRoute] Guid id)
        {
            return _productLogic.GetComments(id);
        }
    }
}