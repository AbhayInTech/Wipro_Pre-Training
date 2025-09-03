using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationValidationDemo.Models;

namespace RegistrationValidationDemo.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public UserRegistration UserRegistration { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Here you would typically save the user to a database
            // For this demo, we'll just redirect to a success page or back to index

            TempData["Message"] = "Registration successful!";
            return RedirectToPage("/Index");
        }
    }
}
