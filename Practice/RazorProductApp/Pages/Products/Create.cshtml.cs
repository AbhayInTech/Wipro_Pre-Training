using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;



public class CreateModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new Product
    {
        Categories = new List<Category>
    {
        new Category(),
        new Category(),
        new Category()
    }
    };

    public static List<Product> ProductList = new();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid || Product == null) return Page();
        Product.ProductID = ProductList.Count + 1;
        ProductList.Add(Product);
        return RedirectToPage("List");
    }
}
