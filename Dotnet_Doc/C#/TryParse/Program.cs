using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "vishhnu";

            bool res = int.TryParse(text, out int num1);
            if (res == false)
            {
                Console.WriteLine("text is not num  : " + num1 + 5);
            }
            else
            {
                num1 = num1 + 5;
                Console.WriteLine("text is not num  : " + num1);
            };


            string now = "1/122/7111";
            // Use TryParse on the DateTime type to parse a date.
            DateTime parsed;
            if (DateTime.TryParse(now, out parsed))
            {
                Console.WriteLine(parsed);
            }
            else
            {
                Console.WriteLine(parsed);
            }
            Console.ReadLine();


        }
    }
}
