using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Leaf.xNet;

namespace Parser
{
    class Onliner
    {
        public static string GetPage(string link)
        {
            HttpRequest request = new HttpRequest();
            string response = request.Get(link).ToString();
            return response;
        }

        public static string ParseTover(string response)
        {

            HtmlParser hp = new HtmlParser();
            var doc = hp.ParseDocument(response);

            List<Item> itemList = new List<Item>();

            //var item = doc.QuerySelector("#minWidth > div > div.l-gradient-wrapper > div.b-whbd > div > div.b-ba-grid > div.l-col-1 > div.ba-tbl-list.fleamarket__1 > table > tbody > tr:nth-child(28)");
            //var itemName = item.QuerySelector("h2.wraptxt").TextContent;
            //var itemLink = item.QuerySelector("h2.wraptxt > a").GetAttribute("href");
            //var itemPrice = item.QuerySelector("td.cost").TextContent;
            //var itemDescription = item.QuerySelector("p.ba-description").TextContent;
            //var itemCreated = item.QuerySelector("p.ba-post-edit").TextContent;
            //var itemCity = item.QuerySelector("p.ba-signature > strong").TextContent;

            foreach (var element in doc.QuerySelectorAll("#minWidth > div > div.l-gradient-wrapper > div.b-whbd > div > div.b-ba-grid > div.l-col-1 > div.ba-tbl-list.fleamarket__1 > table > tbody > tr:not(.sorting__1)  "))
            //foreach (var element in doc.QuerySelectorAll("#minWidth > div > div.l-gradient-wrapper > div.b-whbd > div > div.b-ba-grid > div.l-col-1 > div.ba-tbl-list.fleamarket__1 > table > tbody > tr:not(.sorting__1)"))
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
                    //item.Price = Convert.ToInt32(Regex.Match(stringPrice, @"\d+").Value);

                    item.Description = element.QuerySelector("p.ba-description")?.TextContent ?? "No description";
                    //item.Description = element.QuerySelector("p.ba-description").TextContent;
                    item.Created = element.QuerySelector("p.ba-post-edit").TextContent;
                    item.City = element.QuerySelector("p.ba-signature > strong").TextContent;
                }

                itemList.Add(item);

            }

            return "";
        }
    }
}
