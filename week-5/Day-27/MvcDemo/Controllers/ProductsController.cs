using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 999.99M },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 499.99M },
                new Product { Id = 3, Name = "Tablet", Description = "Portable tablet with stylus", Price = 299.99M }
            };
            return View(products);// Pass the list of products to the view
        }

        // for Create.cshtml
        public IActionResult Create()
        {
            // Return the view for creating a new product

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Here you would typically save the product to a database
                // For this example, we will just redirect to the Index action
                return RedirectToAction("Index");
            }
            // If the model state is not valid, return the same view with validation errors
            return View(product);
        }
    }
}
