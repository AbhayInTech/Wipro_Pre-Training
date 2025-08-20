using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("shop")]
    public class StoreController : Controller
    {

        [HttpGet("")]
        [HttpGet("index")] // defining routing with the help of attributes
        public IActionResult Index()
    {
        ViewData["Message"] = "Online Store - implemented via attribute routing";
        return View();
    }

        [HttpGet("category/{categoryName}")]
        public IActionResult ByCategory(string categoryName)
        {
            ViewData["Category"] = categoryName;
            ViewData["Message"] = "Products in category: " + categoryName;
            return View();
        }
        [HttpGet("product/{id:int}")]
        public IActionResult ProductDetails(int id)
        {
            ViewData["ProductId"] = id;
            ViewData["Message"] = $"Details for product: {id} - Attribute Routing with Constraint";
            return View();
        }
    }
}
