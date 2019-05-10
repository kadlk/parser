using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Leaf.xNet;
using Parser;
using System.IO;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = File.ReadAllText(@"D:\Programming\Homework\Parser\onliner.by.HTML");

            //string response = Parser.GetPage("https://baraholka.onliner.by/viewforum.php?f=63&sk=created");
            List<Item> items = Parser.ParsePage(response);
        }


    }
}
