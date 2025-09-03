using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerFeedbackDemo.Models;

namespace CustomerFeedbackDemo.Pages;

public class FeedbackModel : PageModel
{
    [BindProperty]
    public Feedback Feedback { get; set; }

    public static List<Feedback> Feedbacks = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Feedbacks.Add(Feedback);
        Feedback = new Feedback(); // Reset for new submission
        return RedirectToPage("ViewFeedback");
    }
}
