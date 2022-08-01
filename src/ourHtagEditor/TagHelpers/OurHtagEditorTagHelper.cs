using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OurHtagEditor.Models;
using Umbraco.Cms.Core.Models;

namespace OurHtagEditor.TagHelpers
{
    /// <summary>
    /// Generates a H-tag element
    /// </summary>
    [HtmlTargetElement("headline", Attributes = "htag", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class OurHtagEditorTagHelper : TagHelper
    {
        /// <summary>
        /// Sets the H-tag
        /// </summary>
        [HtmlAttributeName("htag")]
        public Headline Headline { get; set; }

        /// <summary>
        /// Adds one or more classes to the H-tag element
        /// </summary>
        [HtmlAttributeName("class")]
        public string Class { get; set; }

        /// <summary>
        /// Adds a link with the provided URL around the H-tag element
        /// </summary>
        [HtmlAttributeName("link")]
        public Link Link { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Link != null)
            {
                var content = output.GetChildContentAsync().Result.GetContent();

                output.TagName = "a";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.Add("href", Link.Url);
                output.Attributes.Add("title", Link.Name);
                if (!string.IsNullOrEmpty(Link.Target))
                {
                	output.Attributes.Add("target", Link.Target);
                	if (Link.Target == "_blank")
                	{
                		output.Attributes.Add("rel", "noopener");
                	}
                }

                var headlineBuilder = new TagBuilder(Headline.Htag);

                if (!string.IsNullOrWhiteSpace(Class))
                {
                    headlineBuilder.Attributes.Add("class", Class);
                }
                headlineBuilder.Attributes.Add("style", $"text-align: {Headline.TextAlign};");
                headlineBuilder.InnerHtml.AppendHtml(Headline.Text);

                output.Content.SetHtmlContent(headlineBuilder);
            }
            else
            {
                output.TagMode = TagMode.StartTagAndEndTag;

                output.TagName = Headline.Htag;
                output.Content.SetContent(Headline.Text);
                output.Attributes.Add("style", $"text-align: {Headline.TextAlign};");

                if (!string.IsNullOrWhiteSpace(Class))
                {
                    output.Attributes.Add("class", Class);
                }
            }
        }
    }
}
