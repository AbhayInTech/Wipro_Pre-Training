using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleAuthDemo.Data;
using RoleAuthDemo.Models;

namespace RoleAuthDemo.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataProtector _protector;
        private const string ProtectorPurpose = "ProductPriceProtector-v1";

        public ProductController(ApplicationDbContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector(ProtectorPurpose);
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.OrderBy(p => p.Id).ToListAsync();
            // decrypt price for view
            var vm = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = TryUnprotectDecimal(p.PriceEncrypted)
            }).ToList();

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var product = new Product
            {
                Name = model.Name,
                PriceEncrypted = _protector.Protect(model.Price.ToString("G")), // store encrypted string
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Product \"{product.Name}\" has been successfully created!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return NotFound();

            var vm = new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = TryUnprotectDecimal(p.PriceEncrypted)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var p = await _context.Products.FindAsync(model.Id);
            if (p == null) return NotFound();

            p.Name = model.Name;
            p.PriceEncrypted = _protector.Protect(model.Price.ToString("G"));
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Product \"{p.Name}\" has been successfully updated!";
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return NotFound();

            return View(p);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return NotFound();

            _context.Products.Remove(p);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Product \"{p.Name}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }

        // helper to decrypt
        private decimal TryUnprotectDecimal(string protectedValue)
        {
            try
            {
                var plain = _protector.Unprotect(protectedValue);
                if (decimal.TryParse(plain, out var d)) return d;
            }
            catch
            {

            }
            return 0m;
        }
    }
}
