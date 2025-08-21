using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesAssignment.Pages.Items
{
    public class AddModel : PageModel
    {
        // Property binding with validation
        [BindProperty]
        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(50, ErrorMessage = "Item name cannot be longer than 50 characters.")]
        public string NewItem { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Validation failed -> stay on Add page
                return Page();
            }

            // Add item to shared static list
            ListModel.ItemsStore.Add(NewItem);

            // Show success message
            TempData["Message"] = $"Item '{NewItem}' added successfully!";

            // Redirect back to List page
            return RedirectToPage("/Items/List");
        }
    }
}
