using Microsoft.AspNetCore.Mvc;
using AdvanceRoutingDemo.Models;

namespace AdvanceRoutingDemo.Controllers;

public class UsersController : Controller
{
    private static readonly List<User> _users = new()
    {
        new User { Username = "admin", Role = "Admin", Email = "admin@example.com" },
        new User { Username = "john", Role = "User", Email = "john@example.com" }
    };

    private static readonly List<Order> _orders = new()
    {
        new Order { Id = 1, Username = "john", ProductId = 1, Quantity = 1, OrderDate = DateTime.Now },
        new Order { Id = 2, Username = "admin", ProductId = 2, Quantity = 2, OrderDate = DateTime.Now }
    };

    // GET: /Users/{username}/Orders
    public IActionResult Orders(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            return NotFound();
        }

        var orders = _orders.Where(o => o.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
        ViewBag.Username = username;
        return View(orders);
    }
}
