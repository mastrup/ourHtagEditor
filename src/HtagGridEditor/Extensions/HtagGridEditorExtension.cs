using HtagGridEditor.Models;
using System.Text;
using System.Web;

namespace HtagGridEditor.Extensions
{
    public static class HtagGridEditorExtension
    {
        /// <summary>
        /// Adds a HTML H-tag
        /// </summary>
        /// <param name="headline"></param>
        /// <returns></returns>
        public static HtmlString GetHtml(this Headline headline)
        {
            StringBuilder hb = new StringBuilder();
            hb.Append("<" + headline.Htag + " style=\"text-align:" + headline.TextAlign + ";\">");
            hb.Append(headline.Text);
            hb.Append("</" + headline.Htag + ">");

            return new HtmlString(hb.ToString());
        }

        /// <summary>
        /// Adds a HTML H-tag with a CSS class
        /// </summary>
        /// <param name="headline"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static HtmlString GetHtml(this Headline headline, string cssClass = "")
        {
            StringBuilder hb = new StringBuilder();
            hb.Append("<" + headline.Htag + " class=\"" + cssClass + "\" style=\"text-align:" + headline.TextAlign + ";\">");
            hb.Append(headline.Text);
            hb.Append("</" + headline.Htag + ">");

            return new HtmlString(hb.ToString());
        }
    }
}
