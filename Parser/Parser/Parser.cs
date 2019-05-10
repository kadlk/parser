using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using Leaf.xNet;

namespace Parser
{
    public class Parser
    {
        public static string GetPage(string link)
        {
            HttpRequest request = new HttpRequest();
            string response = request.Get(link).ToString();
            return response;
        }

        public static List<Item> ParsePage(string response)
        {
            HtmlParser hp = new HtmlParser();
            var doc = hp.ParseDocument(response);
            List<Item> itemList = new List<Item>();

            foreach (var element in doc.QuerySelectorAll("#minWidth > div > div.l-gradient-wrapper > div.b-whbd > div > div.b-ba-grid > div.l-col-1 > div.ba-tbl-list.fleamarket__1 > table > tbody > tr:not(.sorting__1)  "))
            {
                Item item = new Item();
                item.Name = element.QuerySelector("h2.wraptxt")?.TextContent ?? "No item";
                if (!item.Name.Equals("No item"))
                {
                    item.Link = element.QuerySelector("h2.wraptxt > a").GetAttribute("href");
                    string stringPrice = element.QuerySelector("td.cost").TextContent;

                    try
                    {
                        item.Price = Convert.ToInt32(Regex.Match(stringPrice, @"\d+").Value);
                    }
                    catch (FormatException)
                    {
                        item.Price = 0;
                    }

                    item.Description = element.QuerySelector("p.ba-description")?.TextContent ?? "No description";
                    item.Created = element.QuerySelector("p.ba-post-edit").TextContent;
                    item.City = element.QuerySelector("p.ba-signature > strong").TextContent;

                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}



