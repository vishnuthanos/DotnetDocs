using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicitionaryEx
{
    class Program1
    {

        public class Country
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string Capital { get; set; }
        }


        static void Main(string[] args)
        {
            Country country1 = new Country()
            {
                Code = "AUS",
                Name = "AUSTRALIA",
                Capital = "Canberra"
            };

            Country country2 = new Country()
            {
                Code = "IND",
                Name = "INDIA ",
                Capital = "New Delhi"
            };

            Country country3 = new Country()
            {
                Code = "USA",
                Name = "UNITED STATES",
                Capital = "Washington D.C."
            };

            Country country4 = new Country()
            {
                Code = "GBR",
                Name = "UNITED KINGDOM",
                Capital = "London"
            };

            Country country5 = new Country()
            {
                Code = "CAN",
                Name = "CANADA",
                Capital = "Ottawa"
            };
            Dictionary<string, Country> dictionaryCountries = new Dictionary<string, Country>();
        dictionaryCountries.Add(country1.Code, country1);
        dictionaryCountries.Add(country2.Code, country2);
        dictionaryCountries.Add(country3.Code, country3);
        dictionaryCountries.Add(country4.Code, country4);
        dictionaryCountries.Add(country5.Code, country5);

            foreach (KeyValuePair<string, Country> author in dictionaryCountries)
            {
                Console.WriteLine("Key: {0}, Value: {1},{2}", author.Key, author.Value.Name.ToString(), author.Value.Capital.ToString());
            }

            Console.ReadLine();

        }
    }
}
