using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementDemo.Filters;

public class ProductController : Controller
{

    [HttpGet("products/{id:int}")]
    [ServiceFilter(typeof(ProductCacheResourceFilter))]
    public IActionResult Get(int id) => Content($"Product details for product id: {id} at Time : {DateTime.Now:HH:mm:ss}");
}