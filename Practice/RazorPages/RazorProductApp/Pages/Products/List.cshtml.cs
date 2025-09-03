using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages.Products
{
    public class ListModel : PageModel
    {
        public List<Product> Products => CreateModel.ProductList;
    }
}
