using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @out
{
    class Program
    {

        public static void methode1()
        {
            Console.WriteLine("methode1");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("vishnu");
            bool res;
            int a;
            string myStr = "vishnu" +
                "";
            res = int.TryParse(myStr, out a);
            Console.WriteLine("String is a numeric representation: " + res);
            Console.WriteLine("=============================== ");


            // Convert string to number.
            string text = "500";
            int num = int.Parse(text);
            Console.WriteLine(num);





            #region Part 2
            using (var db = new SchoolDB1Entities())
            {
                // If using Code First we need to make sure the model is built before we open the connection
                // This isn't required for models created with the EF Designer
                // db.Database.Initialize(force: false);

                // Create a SQL command to execute the sproc
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "[dbo].[foursp]";

                try
                {

                    db.Database.Connection.Open();
                    // Run the sproc
                    var reader = cmd.ExecuteReader();

                    // Read Blogs from the first result set
                    var blogs = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<Student>(reader, "Students", MergeOption.AppendOnly);

                    Console.WriteLine(" 1st table Student table");
                    foreach (var item in blogs)
                    {
                        Console.WriteLine(" Student Name:" + item.StudentName);
                    }
                    Console.WriteLine(" ======================");
                    // Move to second result set and read Posts
                    reader.NextResult();
                    var posts = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<Standard>(reader, "Standards", MergeOption.AppendOnly);

                    Console.WriteLine(" 2nd table Standard table");
                    foreach (var item in posts)
                    {
                        Console.WriteLine("Standard Name :" + item.StandardName);
                    }
                    Console.WriteLine("=============================");

                    Console.WriteLine(" 3nd table Teacher table");

                    reader.NextResult();
                    var posts1 = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<Teacher>(reader, "Teachers", MergeOption.AppendOnly);


                    foreach (var item in posts1)
                    {
                        Console.WriteLine("Teacher" + ":" + item.TeacherName);
                    }
                    Console.WriteLine("=============================");



                    reader.NextResult();
                    var Courseslist = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<Course>(reader, "Courses", MergeOption.AppendOnly);


                    foreach (var item in Courseslist)
                    {
                        Console.WriteLine("Courses" + ":" + item.CourseName);
                    }


                    Console.WriteLine("=============================");



                    // Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    Program.methode1();
                    Console.ReadLine();
                    db.Database.Connection.Close();
                }
            }
            #endregion






        }
    }
}
