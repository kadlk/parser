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
            string temp2 = "252,23 р.";
            string temp = "\n                        ";
            string resultString = Regex.Match(temp, @"\d+").Value;
            Console.WriteLine(resultString);
            Console.Read();
        }
    }
}
