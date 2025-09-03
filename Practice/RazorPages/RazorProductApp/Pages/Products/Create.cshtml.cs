using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages.Products
{
    public class CreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category1 { get; set; } = string.Empty;
        public string Category2 { get; set; } = string.Empty;
    }

    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateViewModel ViewModel { get; set; } = new();

        public static List<Product> ProductList = new()
    {
        new Product
        {
            ProductID = 1,
            Name = "Laptop",
            Description = "High-performance laptop for work and gaming",
            Categories = new List<Category>
            {
                new Category { CategoryName = "Electronics" },
                new Category { CategoryName = "Computers" }
            }
        },
        new Product
        {
            ProductID = 2,
            Name = "Coffee Maker",
            Description = "Automatic coffee maker with programmable timer",
            Categories = new List<Category>
            {
                new Category { CategoryName = "Appliances" },
                new Category { CategoryName = "Kitchen" }
            }
        },
        new Product
        {
            ProductID = 3,
            Name = "Running Shoes",
            Description = "Comfortable running shoes for all terrains",
            Categories = new List<Category>
            {
                new Category { CategoryName = "Sports" },
                new Category { CategoryName = "Footwear" }
            }
        },
        new Product
        {
            ProductID = 4,
            Name = "Wireless Headphones",
            Description = "Noise-cancelling wireless headphones with long battery life",
            Categories = new List<Category>
            {
                new Category { CategoryName = "Electronics" },
                new Category { CategoryName = "Audio" }
            }
        },
        new Product
        {
            ProductID = 5,
            Name = "Yoga Mat",
            Description = "Non-slip yoga mat for home workouts",
            Categories = new List<Category>
            {
                new Category { CategoryName = "Sports" },
                new Category { CategoryName = "Fitness" }
            }
        }
    };

        public void OnGet()
        {
            ViewModel = new CreateViewModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var product = new Product
            {
                ProductID = ProductList.Count + 1,
                Name = ViewModel.Name,
                Description = ViewModel.Description,
                Categories = new List<Category>
        {
            new Category { CategoryName = ViewModel.Category1 },
            new Category { CategoryName = ViewModel.Category2 }
        }
            };

            ProductList.Add(product);
            return RedirectToPage("List");
        }
    }
}
