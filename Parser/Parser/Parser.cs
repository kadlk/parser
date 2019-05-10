using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using Leaf.xNet;

namespace Parser
{
    public class Parser
    {
        public static string Parse(string resopnse)
        {
            HtmlParser hp = new HtmlParser();
            var doc = hp.ParseDocument(resopnse);
            string x = doc.QuerySelector("td.frst.ph.colspan").InnerHtml;
            return x;
        }
    }


}
