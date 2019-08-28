using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {// Create a dictionary with string key and Int16 value pair    
            Dictionary<string, Int16> AuthorList = new Dictionary<string, Int16>();
            AuthorList.Add("Mahesh Chand", 35);
            AuthorList.Add("Mike Gold", 25);
            AuthorList.Add("Praveen Kumar", 29);
            AuthorList.Add("Raj Beniwal", 21);
            AuthorList.Add("Dinesh Beniwal", 84);
            // Count    
            Console.WriteLine("Count: {0}", AuthorList.Count);
            // Set Item value    
            AuthorList["Neel Beniwal"] = 9;
            if (!AuthorList.ContainsKey("Mahesh Chand"))
            {
                AuthorList["Mahesh Chand"] = 20;
            }
            if (!AuthorList.ContainsValue(9))
            {
                Console.WriteLine("Item found");
            }
            Console.WriteLine("Count: {0}", AuthorList.Count);
            // Read all items    
            Console.WriteLine("Authors all items:");
            foreach (KeyValuePair<string, Int16> author in AuthorList)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                author.Key, author.Value);
            }
            // Remove item with key = 'Mahesh Chand'    
            AuthorList.Remove("Mahesh Chand");
            Console.WriteLine("Count: {0}", AuthorList.Count);
            Console.WriteLine("Remove item with key = 'Mahesh Chand'    ");
            foreach (KeyValuePair<string, Int16> author in AuthorList)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                author.Key, author.Value);
            }







           
           

            if (!AuthorList.ContainsKey("vishnu")) //ContainsKey returns a Boolean
            {
                AuthorList.Add("vishnukey", 55);
              
                Console.WriteLine("searcg conatain key " + AuthorList.Count);
            }

            if (!AuthorList.ContainsValue(111)) //ContainsKey returns a Boolean
            {
                AuthorList.Add("vishnuval", 111);
                Console.WriteLine("search  value" + AuthorList.Count );
            }

            if (!AuthorList.ContainsValue(111)) //ContainsKey returns a Boolean
            {
                AuthorList.Add("vishnu", 111);
                Console.WriteLine("vishnu added t"+ AuthorList.Count);
                Console.WriteLine("Count: {0}", AuthorList.Count);
            }


            Console.WriteLine("clear all    ");
            // Remove all items    
            AuthorList.Clear();


            Console.WriteLine("Count: {0}", AuthorList.Count);

            foreach (KeyValuePair<string, Int16> author in AuthorList)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                author.Key, author.Value);
            }
            Console.ReadLine();
        }
    }
}
