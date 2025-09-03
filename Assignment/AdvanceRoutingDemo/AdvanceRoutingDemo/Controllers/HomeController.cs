using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdvanceRoutingDemo.Models;

namespace AdvanceRoutingDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // GET: /Home/Dashboard?role=Admin
    public IActionResult Dashboard(string role)
    {
        // Dynamic routing based on role
        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
        {
            ViewBag.Message = "Welcome to Admin Dashboard";
            ViewBag.Role = "Admin";
            // Could redirect or serve different view
            return View("AdminDashboard");
        }
        else if (string.Equals(role, "User", StringComparison.OrdinalIgnoreCase))
        {
            ViewBag.Message = "Welcome to User Dashboard";
            ViewBag.Role = "User";
            return View("UserDashboard");
        }
        else
        {
            // Default or redirect
            return RedirectToAction("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
