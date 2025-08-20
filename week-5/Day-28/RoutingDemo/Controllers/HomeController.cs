using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Models;

namespace RoutingDemo.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        ViewData["Message"] = "This is my about us page view.";
        //view data is used for passing data from controller to view( statemanagement)
        //Viewbag can also be used for same purpose
        return View();
    }

    public IActionResult Contact(string department = "general")
    {
        ViewData["Department"] = department ;
        ViewData["Message"] = $"Contact page for {department} department.";
        return View();
    }
}
