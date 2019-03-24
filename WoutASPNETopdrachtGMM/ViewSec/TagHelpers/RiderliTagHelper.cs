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
    /// <see cref="https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-2.2"/>
    public class RiderLiTagHelper : TagHelper
    {
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";    // Replaces <rider-li> with <li> tag
            output.AddClass("list-group-item", HtmlEncoder.Default);
            output.AddClass("d-flex", HtmlEncoder.Default);
            output.AddClass("justify-content-between", HtmlEncoder.Default);
            output.AddClass("align-items-center", HtmlEncoder.Default);
            output.Content.SetHtmlContent(
                $@"{For.Name.Split('.').Last()}
                <span class=""badge badge-primary badge-pill ml-2"">{For.Model}</span>"
            );
        }
    }
}
