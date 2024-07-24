using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Northwind.Helpers
{
    [HtmlTargetElement("img-link")]
    public class ImageLinkTagHelper : TagHelper
    {
        public int ImageId { get; set; }
        public string Alt { get; set; }
        public string LinkCssClass { get; set; }
        public string ImgCssClass { get; set; }
        public string ImgWidth { get; set; }
        public string ImgHeight { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string linkHref = $"/images/{ImageId}";
            string imgSrc = $"/images/{ImageId}";

            output.TagName = "a";
            output.Attributes.SetAttribute("href", linkHref);

            var imgTag = new TagBuilder("img");
            imgTag.Attributes.Add("src", imgSrc);
            imgTag.Attributes.Add("alt", Alt);


            output.Content.SetHtmlContent(imgTag);
        }
    }
}
