using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_LSP
{
    class Program
    {
       
        public class Apple1
        {
            public virtual string GetColor()
            {
                return "Red";
            }
        }
        public class Orange : Apple1
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }
        static void Main(string[] args)
    {

            Apple1 apple = new Orange();
                    Console.WriteLine(apple.GetColor());
            Console.WriteLine("===================================");







            Orange fruit = new Orange();
        Console.WriteLine(fruit.GetColor());
        Apple n = new Apple();
        Console.WriteLine(n.GetColor());



            // Create a dictionary with string key and Int16 value pair    
            Dictionary<string, string> AuthorList = new Dictionary<string, string>();
            AuthorList.Add("Mahesh Chand", "teja");
            AuthorList.Add("Mike Gold", "teja");
            AuthorList.Add("Praveen Kumar", "ttejaaa");
            AuthorList.Add("Raj Beniwal", "2reiuo51");
            AuthorList.Add("Dinesh Beniwal", "karan");
            // Read all data    

            // To get count of key/value pairs in myDict 
            Console.WriteLine("Total key/value pairs" +
                  " in myDict are : " + AuthorList.Count);
            AuthorList.Remove("Dinesh Beniwal");
            // Displaying the key/value pairs in myDict 
           
            Console.WriteLine("Total key/value pairs" +
                 " in myDict are : " + AuthorList.Count);


            Console.WriteLine("Authors List");
            foreach (KeyValuePair<string, string> author in AuthorList)
            {
                Console.WriteLine(" {1},  {0}", author.Value, author.Value);
            }



            Console.ReadLine();
    }
}
public abstract class Fruit
{
    public abstract string GetColor();
}
public class Apple : Fruit
{
    public override string GetColor()
    {
        return "apple";
    }
}
public class Orange : Apple
{
    public override string GetColor()
    {
        return "Orange";
    }

}















}