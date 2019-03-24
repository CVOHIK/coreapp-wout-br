using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Text.Encodings.Web;
using BusinessFacade;

namespace ViewSec.TagHelpers
{
    public class VerantwoordelijkeTagHelper : TagHelper
    {
        public ICollection<Member> Members { get; set; }
        public string Functie{ get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var filteredMembers = Members.Where(m => m.Function.Name.Equals(Functie)).ToHashSet();
            output.TagName = "div";
            output.AddClass("persoon", HtmlEncoder.Default);

            string outputString = $"<h4>{Functie}</h4>";
            if (filteredMembers.Count == 1)
            {
                output.AddClass("col-md-6", HtmlEncoder.Default);
                Member m = filteredMembers.First();
                outputString += $@"<p>{m.Name}</p>
                    <p><label>Tel.</label>{m.Gsm}</p>
                    <p><label>Email</label>{m.Email}</p>";
            }
            else if(filteredMembers.Count > 1)
            {
                output.AddClass("col-md-12", HtmlEncoder.Default);
                outputString += "<div class=\"d-flex flex-wrap\">";
                foreach (var m in filteredMembers)
                {
                    outputString += $"<p class=\"col-md-6\">{m.Name}</p>";
                }
                outputString += "</div>";
            }
            output.Content.SetHtmlContent(outputString);
        }
    }
}
