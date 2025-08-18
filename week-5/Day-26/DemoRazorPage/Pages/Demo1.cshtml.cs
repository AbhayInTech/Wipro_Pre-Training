using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages
{
    public class Demo1Model : PageModel
    {
        // property bounnd to the page
        public string Message { get; set; } = "Hello, Razor Pages!";
        public string? Name { get; set; } = "John Doe";
        public void OnGet() 
        {
            // handler method for GET requests
            // You can set the Message property here or in the constructor
            Message = "This was set in OnGet() method.";
        }
        public void OnPost()
        {
            // This method handles POST requests
            // You can add logic here to handle form submissions or other POST actions
            Message = "This was set in OnPost() method.";
        }
    }
}
