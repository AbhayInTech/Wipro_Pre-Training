using Microsoft.AspNetCore.Mvc;
using RepoDemo.Api.Models;
using RepoDemo.Api.Repository.Interfaces;

namespace RepoDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Implement the actions for the ProductsController
        // To see this in action, navigate to /api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
