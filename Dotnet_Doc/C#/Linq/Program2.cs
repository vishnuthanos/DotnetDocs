using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linqa
{
    class Program2
    {
        static void Main(string[] args)
        {
            IList<string> stringList = new List<string>() {
            "Product",
            "Items",
            "Logs",
            "Employeess" ,
            "HRss"
        };

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("s")
                         select s;
           
            var result1 = stringList.Where(s => s.Contains("ss"));

            foreach (var str in result)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("=====================");
            foreach (var str1 in result1)
            {
                Console.WriteLine(str1);
            }













            Console.ReadKey();
        }
    }
}
