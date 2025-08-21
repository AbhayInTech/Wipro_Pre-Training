using Microsoft.AspNetCore.Mvc;
using BlogDemo.Models;

namespace BlogDemo.Controllers;

public class ProductController : Controller
{
    private static readonly List<Product> productList = new List<Product>
{
    new Product
    {
        Id = 1,
        Name = "Samsung Galaxy S23 Ultra",
        Image = "https://th.bing.com/th/id/OIP.2HFtW-tmli-lclS2Nq4ruQHaHk?w=192&h=196&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3",
        Description = "Flagship smartphone with 200MP camera, Snapdragon 8 Gen 2, and stunning AMOLED display.",
        Slug = "samsung-galaxy-s23-ultra",
        Price = 124999.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 2,
        Name = "Apple MacBook Air M2",
        Image = "https://tse4.mm.bing.net/th/id/OIP.ogk1FTG_Rqq98Erg_XP_UQHaFs?pid=ImgDet&w=197&h=151&c=7&dpr=1.3&o=7&rm=3",
        Description = "Lightweight and powerful laptop with Apple M2 chip, 13.6-inch Liquid Retina display.",
        Slug = "macbook-air-m2",
        Price = 109900.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 3,
        Name = "Sony WH-1000XM5 Headphones",
        Image = "https://th.bing.com/th/id/OIP.Jo7OJfpRTCHH2OwwSVjlwwHaHa?w=183&h=183&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3",
        Description = "Industry-leading noise cancellation with premium sound and 30-hour battery life.",
        Slug = "sony-wh-1000xm5-headphones",
        Price = 29990.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 4,
        Name = "Dell XPS 15 Laptop",
        Image = "https://tse2.mm.bing.net/th/id/OIP.QnLRDM9EZUyBJlbRqLBBFAHaEg?rs=1&pid=ImgDetMain&o=7&rm=3",
        Description = "High-performance laptop with Intel Core i7, NVIDIA RTX graphics, and 4K display.",
        Slug = "dell-xps-15-laptop",
        Price = 149999.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 5,
        Name = "Samsung Galaxy Watch 6",
        Image = "https://tse1.mm.bing.net/th/id/OIP.492WQ8Vtade6s0UgufNSiQHaHa?pid=ImgDet&w=197&h=197&c=7&dpr=1.3&o=7&rm=3",
        Description = "Smartwatch with advanced health tracking, AMOLED display, and long battery life.",
        Slug = "samsung-galaxy-watch-6",
        Price = 29999.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 6,
        Name = "Lenovo Legion 5 Pro",
        Image = "https://th.bing.com/th/id/OIP.CqGKrlY872T_G8hsOFi_8wHaFJ?w=224&h=180&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3",
        Description = "Gaming laptop with AMD Ryzen 7, RTX 3060, and 165Hz QHD display.",
        Slug = "lenovo-legion-5-pro",
        Price = 129990.00m,
        CreatedAt = DateTime.Now
    },
    new Product
    {
        Id = 7,
        Name = "OnePlus Buds Pro 2",
        Image = "https://tse4.mm.bing.net/th/id/OIP.segLn36AkDg0sdyD6JxBUwHaHa?pid=ImgDet&w=197&h=197&c=7&dpr=1.3&o=7&rm=3",
        Description = "Premium wireless earbuds with spatial audio, ANC, and fast charging.",
        Slug = "oneplus-buds-pro-2",
        Price = 11999.00m,
        CreatedAt = DateTime.Now
    }
};

    [Route("product/{slug}")]
    public IActionResult Items(string slug)
    {
        var product = productList.FirstOrDefault(p => p.Slug == slug);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}
