using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Northwind.Helpers
{
    public static class ImageLinkHtmlHelper
    {
        public static IHtmlContent NorthwindImageLink(this IHtmlHelper htmlHelper, int imageId, string altText)
        {
            string linkHref = $"/images/{imageId}";
            string imgSrc = $"/images/{imageId}";

            var linkTag = new TagBuilder("a");
            linkTag.Attributes.Add("href", linkHref);

            var imgTag = new TagBuilder("img");
            imgTag.Attributes.Add("src", imgSrc);
            imgTag.Attributes.Add("alt", altText);

            linkTag.InnerHtml.AppendHtml(imgTag);

            var writer = new System.IO.StringWriter();
            linkTag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}
