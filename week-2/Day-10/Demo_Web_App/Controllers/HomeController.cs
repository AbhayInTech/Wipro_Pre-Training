using Microsoft.AspNetCore.Mvc;

namespace Demo_Web_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();//We will use for rendering a HTML page
            
        }
    }
}
