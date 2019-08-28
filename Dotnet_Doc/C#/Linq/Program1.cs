using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInq2
{
    class Program1
    {
        static void Main(string[] args)
        {
            IList<Patient> PatientList = new List<Patient>() { 
                new Patient() { PateintId = 1, PateintName = "John", Adress = "" } ,
				new Patient() { PateintId = 2, PateintName = "Moin", Adress = "" } ,
				new Patient() { PateintId = 3, PateintName = "Bill", Adress = "" } ,
				new Patient() { PateintId = 4, PateintName = "Ram", Adress = "" } ,
				new Patient() { PateintId = 5, PateintName = "Ron", Adress = "" }

            };

            var x = from s in PatientList where s.PateintName.Contains("Ram") select s;

            foreach(Patient p in x)
            {
                Console.Write(p.PateintName + " ;" + p.PateintId);
            }

            Console.ReadKey();
    }

    public class Patient
        {
            public int PateintId { set; get; }

            public string PateintName { set; get; }

            public string Adress { set; get;
            }
        }
        
    }
}
