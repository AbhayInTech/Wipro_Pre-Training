using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simpleSessionDemo.Models;

namespace simpleSessionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // gett he current count from session
        int visitCount = HttpContext.Session.GetInt32("visitCount") ?? 0;
        // using ?? 0 to provide a default value if the session variable is null
        visitCount++;
        HttpContext.Session.SetInt32("visitCount", visitCount);//storing the new count to the session 
        return View(visitCount);

        //if we dont want to pass the count to the view, we can simply return the view without any parameters

        // using  inbuilt Key value pair variables are ViewData and ViewBag

        //both ViewData and ViewBag can be used to pass data from controller to view



        // ViewData is a dictionary object and ViewBag is a dynamic object

        // ViewData["VisitCount"] = visitCount; // key value pair

        // or

        // ViewBag.VisitCount = visitCount; // dynamic object using properties

        // View State which was prominent in earlier version of ASP.NET web app






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

    public IActionResult Reset()
    {
        // Reset the visit count in session

        //HttpContext.Session.SetInt32("visitCount", 0);
        HttpContext.Session.Remove("visitCount"); // removes the specific key from session
        // HttpContext.Session.Clear(); // clears all the session data
        return RedirectToAction("Index");
    }
}
