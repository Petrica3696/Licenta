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

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            _productLogic.Create(productDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateProductDto productDto)
        {
            _productLogic.Update(id, productDto);
            return NoContent();
        }
    }
}