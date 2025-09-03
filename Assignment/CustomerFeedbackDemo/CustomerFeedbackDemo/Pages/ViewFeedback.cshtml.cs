using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerFeedbackDemo.Models;

namespace CustomerFeedbackDemo.Pages;

public class ViewFeedbackModel : PageModel
{
    public List<Feedback> Feedbacks { get; set; }

    public void OnGet()
    {
        Feedbacks = FeedbackModel.Feedbacks;
    }
}
