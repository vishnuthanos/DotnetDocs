using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Doc.Linq
{
   public class LinqSkip
    {
        IList<string> myList = new List<string>()
            {
                "vishnu","ramu","charan","sathish"
        };

        //  var newList = myList.Skip(3);
        var x = myList.Take(2);
        foreach (var str in x)
            Console.WriteLine(str);
        Console.ReadLine();

    
}
}
