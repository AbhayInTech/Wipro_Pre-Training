using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesAssignment.Pages.Items
{
    public class ListModel : PageModel
    {
        // Shared static list to hold items in memory
        public static List<string> ItemsStore { get; set; } = new();

        // Property to bind and display items on the page
        public List<string> Items { get; set; } = new();

        public void OnGet()
        {
            // Populate items from static store
            Items = ItemsStore;
        }
    }
}
