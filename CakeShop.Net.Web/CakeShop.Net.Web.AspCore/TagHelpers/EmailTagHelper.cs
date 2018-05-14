using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace CakeShop.Net.Web.AspCore.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content);
        }
    }
}