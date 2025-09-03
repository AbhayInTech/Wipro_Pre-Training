using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackDemo.Models;

public class Feedback
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    public string Comments { get; set; }
}
