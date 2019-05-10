using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp3 = "создано\n                \t\t\t\t1 час назад                \t\t\t";
            string temp2 = "Привет ывфы фыфф";
            string temp = "\n                        ";
            //string resultString = Regex.Match(temp, @"\d+").Value;
            //string output = Regex.Replace(temp3, @"\s", "");
            //string newStrstr = Regex.Replace(temp3, @"(?<![A-Za-z])'|'(?![A-Za-z])|[^A-Za-z0-9']", "");
            string newStrstr = Regex.Replace(temp3, @" {2,}", "");
            string newStrstr2 = Regex.Replace(newStrstr, "\\\n{2,}", "");

            Console.WriteLine(newStrstr);
            Console.Read();
        }
    }
}
