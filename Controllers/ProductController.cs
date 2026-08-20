using Crud_Operation_with_Repo.Models;
using Crud_Operation_with_Repo.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operation_with_Repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;
        public ProductController(IProductServices productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var prod = _productService.GetAllProducts();
            return Ok(prod);

        }
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _productService.Getbyid(id);
            return Ok(prod);

        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            _productService.CreateProduct(product);
            return Ok("Product Added Successfully");
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest("Product is null or ID mismatch.");
            }
            _productService.UpdateProduct(product);
            return Ok("Product Updated Successfully");
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok("Product Deleted Successfully");
        }

    }

}
