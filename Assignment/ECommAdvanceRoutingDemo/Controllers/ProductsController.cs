using Microsoft.AspNetCore.Mvc;
using ECommAdvanceRoutingDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommAdvanceRoutingDemo.Controllers
{
    public class ProductsController : Controller
    {
        public static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1000, Description = "A powerful laptop" },
            new Product { Id = 2, Name = "Book", Category = "Books", Price = 20, Description = "A great book" },
            new Product { Id = 3, Name = "Phone", Category = "Electronics", Price = 500, Description = "A smartphone" },
            new Product { Id = 4, Name = "Shirt", Category = "Clothing", Price = 30, Description = "A cotton shirt" },
        };

        public IActionResult Index(string category)
        {
            var products = _products.Where(p => p.Category == category).ToList();
            ViewBag.Category = category;
            return View(products);
        }

        public IActionResult Details(string category, int id)
        {
            var product = _products.FirstOrDefault(p => p.Category == category && p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Filter(string category, string priceRange)
        {
            var parts = priceRange.Split('-');
            if (parts.Length != 2 || !decimal.TryParse(parts[0], out var min) || !decimal.TryParse(parts[1], out var max))
                return BadRequest("Invalid price range");
            var products = _products.Where(p => p.Category == category && p.Price >= min && p.Price <= max).ToList();
            ViewBag.Category = category;
            ViewBag.PriceRange = priceRange;
            return View(products);
        }
    }
}
