using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ECommAdvanceRoutingDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // For demo, accept any username/password
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
