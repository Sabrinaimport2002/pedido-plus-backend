using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedido_plus_backend.Dtos.Product;
using pedido_plus_backend.Models;
using pedido_plus_backend.Services.Interfaces;

namespace pedido_plus_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            await _productService.CreateProduct(productDto);

            return new CreatedAtRouteResult("GetProduct", productDto);
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct([FromRoute] int id)
        {
            await _productService.DeleteProduct(id);

            return Ok("Produto deletado!");
        }

        [HttpGet("GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(int? id)
        {
            if (id.HasValue)
            {
                var product = await _productService.GetProductById(id.Value);
                if (product == null)
                    return NotFound("Produto não encontrado.");

                return Ok(product);
            }
            else
            {
                var products = await _productService.GetProducts();
                if (products == null || products.Count == 0)
                    return NotFound("Produto não encontrado.");

                return Ok(products);
            }
        }

        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] CreateProductDto productDto)
        {
            productDto.Id = id;

            if (productDto == null)
                return BadRequest();

            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }
    }
}