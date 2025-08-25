using System.Data;
using Microsoft.Data.SqlClient;
using MvcADO_Demo.Data;
using Microsoft.AspNetCore.Mvc;

namespace MvcADO_Demo.controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        // Above variable holds the reference of ProductsRepository class

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        // Action to display the list of products
        public IActionResult Index()
        {
            var dataSet = _productsRepository.GetProducts();
            return View(dataSet.Tables[0]); // Passing the first DataTable to the view
        }

        // Action to show the form for adding a new product
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle the form submission for adding a new product
        [HttpPost]
        public IActionResult Create(string name, double price)
        {
            // Here we can insert product into the database with a condition that price should be non-negative
            if (price >= 0 && ModelState.IsValid)
            {
                int newProductId = _productsRepository.InsertProduct(name, price);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}