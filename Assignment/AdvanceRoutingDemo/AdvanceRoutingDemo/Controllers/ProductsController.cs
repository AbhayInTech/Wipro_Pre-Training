using Microsoft.AspNetCore.Mvc;
using AdvanceRoutingDemo.Models;

namespace AdvanceRoutingDemo.Controllers;

public class ProductsController : Controller
{
    private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99m },
        new Product { Id = 2, Name = "Book", Category = "Books", Price = 19.99m },
        new Product { Id = 3, Name = "Shirt", Category = "Clothing", Price = 29.99m }
    };

    // GET: /Products/{category}
    public IActionResult Index(string category)
    {
        var products = _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        ViewBag.Category = category;
        return View(products);
    }

    // GET: /Products/{category}/{id}
    public IActionResult Details(string category, int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id && p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // GET: /Product/{id:guid}
    public IActionResult DetailsByGuid(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.GuidId == id);
        if (product == null)
        {
            return NotFound();
        }
        return View("Details", product); // Reuse Details view
    }
}
