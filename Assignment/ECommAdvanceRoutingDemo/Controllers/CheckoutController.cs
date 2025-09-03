using Microsoft.AspNetCore.Mvc;
using ECommAdvanceRoutingDemo.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ECommAdvanceRoutingDemo.Controllers
{
    public class CheckoutController : Controller
    {
        private const string SessionCartKey = "Cart";

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = GetCart();
            return View(cart);
        }

        private Cart GetCart()
        {
            var cartJson = HttpContext.Session.GetString(SessionCartKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new Cart();
            }
            return JsonSerializer.Deserialize<Cart>(cartJson);
        }
    }
}
