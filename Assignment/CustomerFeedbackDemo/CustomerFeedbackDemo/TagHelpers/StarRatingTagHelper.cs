using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomerFeedbackDemo.TagHelpers;

[HtmlTargetElement("star-rating")]
public class StarRatingTagHelper : TagHelper
{
    public int Value { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "star-rating");
        var html = "";
        for (int i = 1; i <= 5; i++)
        {
            if (i <= Value)
                html += "<span class='star filled'>&#9733;</span>"; // Filled star
            else
                html += "<span class='star'>&#9734;</span>"; // Empty star
        }
        output.Content.SetHtmlContent(html);
    }
}
