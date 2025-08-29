
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class ListModel : PageModel
{
    public List<Product> Products => CreateModel.ProductList;
}
