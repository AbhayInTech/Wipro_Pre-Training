using Microsoft.AspNetCore.Mvc;
using BlogDemo.Models;

namespace BlogDemo.Controllers;

    public class BlogController : Controller
    {
        private static readonly List<BlogPost> blogPosts = new List<BlogPost>
        {
            new BlogPost { Id = 1, Title = "What is ASP.NET Core?", Slug = "what-is-aspnet-core", Content = "ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.", CreatedAt = DateTime.Now },

            new BlogPost { Id = 2, Title = "Getting Started with ASP.NET Core", Slug = "getting-started-aspnet-core", Content = "Here are some steps to get started with ASP.NET Core.", CreatedAt = DateTime.Now },

            new BlogPost { Id = 3, Title = "Understanding MVC in ASP.NET Core", Slug = "understanding-mvc-aspnet-core", Content = "This is the content of the third post.", CreatedAt = DateTime.Now },

            new BlogPost { Id = 4, Title = "Building RESTful APIs with ASP.NET Core", Slug = "building-restful-apis-aspnet-core", Content = "Learn how to build RESTful APIs using ASP.NET Core.", CreatedAt = DateTime.Now }
        };

        [Route("blog/{slug}")]
        public IActionResult Details(string slug)
        {
            var blogPost = blogPosts.FirstOrDefault(p => p.Slug == slug);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }
    }
