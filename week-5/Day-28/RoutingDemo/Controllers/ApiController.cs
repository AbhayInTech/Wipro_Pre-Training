using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            // Simulate fetching data from a database
            var products = new[]
            {
                new { Id = 1, Name = "Product 1", Price = 10.0 },
                new { Id = 2, Name = "Product 2", Price = 20.0 },
                new { Id = 3, Name = "Product 3", Price = 30.0 }
            };
            return Ok(products);
        }

        [HttpGet("products/{id:int}")]
        public IActionResult GetProduct(int id)
        {
            // Simulate fetching a single product by ID
            var product = new { Id = id, Name = $"Product {id}", Price = id * 10.0 };
            return Ok(product);
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = new { Message = "API is running", Timestamp = DateTime.UtcNow };
            return Ok(status);
        }

        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            var version = new { Version = "1.0.0", ReleaseDate = "2023-10-01", FrameworkName = ".NET 8" };
            return Ok(version);
        }
    }
}
