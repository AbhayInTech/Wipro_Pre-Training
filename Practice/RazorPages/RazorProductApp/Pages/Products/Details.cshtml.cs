using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;
using System.Linq;

namespace RazorProductApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; } = new(); // Fixes CS8618

        public IActionResult OnGet(int id)
        {
            var found = CreateModel.ProductList.FirstOrDefault(p => p.ProductID == id);
            if (found == null) return NotFound();

            Product = found; // Safe assignment
            return Page();
        }
    }
}
