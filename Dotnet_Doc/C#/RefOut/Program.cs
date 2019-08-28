using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculation;
namespace Parameters
{
    class Program
    {
        static void Add(int count)
        {
            count = count + 10;
        }

        static void Addout( out int count)
        {
            count = 0;
             count = count + 10;
        }


        static void Add(ref int count)
        {
           
            count = count + 10;
        }


        public static string GetNextName(int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }
        public static string GetNextName(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
            
        }
        static void Main(string[] args)
        {
             int count = 10;
            Add(count);
            Console.WriteLine(count + " : val");
            Add(ref count);
            Console.WriteLine(count + " : ref");
            int x;
            Addout(out x);
            Console.WriteLine(x + " :out");
            Console.WriteLine( " =============================================");
           
            int Vishnu = 21;
            Console.WriteLine("vishnu value  " + Vishnu);
            GetNextName(Vishnu);
            Console.WriteLine("vishnu value  1 " + Vishnu);
            Console.WriteLine(GetNextName(Vishnu));
            Console.WriteLine("vishnu value  2 " + Vishnu);
            GetNextName(ref Vishnu);
            Console.WriteLine("vishnu value  1 ref " + Vishnu);
            Console.WriteLine(GetNextName(ref Vishnu));
            Console.WriteLine("vishnu value  2 ref " + Vishnu);
            Console.ReadLine();
        }
    }
}
