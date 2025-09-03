using Microsoft.AspNetCore.Mvc;
using ECommAdvanceRoutingDemo.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ECommAdvanceRoutingDemo.Controllers
{
    public class CartController : Controller
    {
        private const string SessionCartKey = "Cart";

        private Cart GetCart()
        {
            var cartJson = HttpContext.Session.GetString(SessionCartKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new Cart();
            }
            return JsonSerializer.Deserialize<Cart>(cartJson);
        }

        private void SaveCart(Cart cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(SessionCartKey, cartJson);
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var cart = GetCart();
            var product = ProductsController._products.Find(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartItem = cart.Items.Find(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { Product = product, Quantity = 1 });
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}
