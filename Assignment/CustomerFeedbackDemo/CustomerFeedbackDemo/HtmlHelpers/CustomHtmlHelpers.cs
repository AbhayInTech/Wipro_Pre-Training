using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Html;

namespace CustomerFeedbackDemo.HtmlHelpers;

public static class CustomHtmlHelpers
{
    public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string placeholder, string cssClass)
    {
        var tag = new TagBuilder("input");
        tag.Attributes["type"] = "text";
        tag.Attributes["name"] = name;
        tag.Attributes["placeholder"] = placeholder;
        tag.Attributes["class"] = cssClass;
        return tag;
    }
}
