using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extension
{
    public static class myclass
    {
        public class calculation
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public int sub(int a, int b)
            {
                return a - b;
            }

            public string Display()
            {
                return ("I m in Display");

            }

            public string Print()
            {
                return ("I m in Print");
            }
        }

        public static void NewMethod(this calculation ob1)
        {
            Console.WriteLine("hello new methode");
        }

        public static string exnewmethode(this calculation ob1)
        {
            return "ex new methode";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            calculation ob = new calculation();
           
            Console.WriteLine("Diaplay : " + ob.Display() );
            Console.WriteLine("print : " + ob.Print());
            Console.WriteLine("Addtion : " + ob.Add(10, 10));
            Console.WriteLine("Subraction : " + ob.sub(10, 110));
            Console.WriteLine("=====================================");
            Console.WriteLine("Extension methode  : " + ob.exnewmethode());
            ob.NewMethod();
            Console.WriteLine("=====================================");

            Console.ReadKey();
        }
    }
}
