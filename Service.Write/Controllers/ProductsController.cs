using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Write.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Write;

namespace Service.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            this._productLogic = productLogic;
        }

        //create product
        [HttpPost]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            _productLogic.Create(productDto);
            return NoContent();
        }

        //create comment
        [HttpPost("submit-comment")]
        public IActionResult CreateComment([FromBody] CommentDto commentDto)
        {
            _productLogic.CreateComment(commentDto);
            return NoContent();
        }

        //edit product informations
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateProductDto productDto)
        {
            _productLogic.Update(id, productDto);
            return NoContent();
        }

        //update bid on product
        [HttpPut("update-bid/{id}")]
        public IActionResult UpdateBid([FromRoute] Guid id, [FromBody] UpdateBid productDto)
        {
            _productLogic.UpdateBid(id, productDto);
            return NoContent();
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            _productLogic.Delete(id);
            return NoContent();
        }

    }
}