using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;



public class DetailsModel : PageModel
{
    public Product? Product { get; set; }

    public IActionResult OnGet(int id)
    {
        Product = CreateModel.ProductList.FirstOrDefault(p => p.ProductID == id);
        if (Product == null) return NotFound();
        return Page();
    }
}
