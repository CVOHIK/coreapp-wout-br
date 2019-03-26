using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Text.Encodings.Web;

namespace ViewSec.TagHelpers
{
    /// <summary>Print a unordered list with comments split over multiple list items</summary>
    /// <example><code><rider-comments comments="@Model.Voorziening.Comments"></rider-comments></code></example>
    public class RiderCommentsTagHelper : TagHelper
    {
        public string Comments { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";    // Replaces <rider-comments> with <ul> tag
            output.AddClass("comments", HtmlEncoder.Default);
            output.AddClass("list-unstyled", HtmlEncoder.Default);
            
            string listItemsString = "";
            if (!String.IsNullOrEmpty(Comments))
            {
                var commentArray = Comments.Split("/n");//TODO save new line char as const in model
                foreach (string c in commentArray)
                {
                    listItemsString += $"<li class=\"list-group-item\">{c}</li>";
                }
            }

            output.Content.SetHtmlContent(listItemsString);
        }
    }
}
