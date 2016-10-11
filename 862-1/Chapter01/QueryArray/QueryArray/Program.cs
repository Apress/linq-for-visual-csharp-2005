using System;
using System.Collections.Generic;
using System.Query;

//using System.Text;
//using System.Data.DLinq;


namespace QueryArray
{
    #region Listing 1-3
    public static class Extensions
    {
        public static string SpaceToUnderscore(this string source)
        {
            char[] cArray = source.ToCharArray();
            string result = null;

            foreach(char c in cArray)
            {
                if (Char.IsWhiteSpace(c))
                    result += "_";
                else
                    result += c;
            }

            return result;
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Data Samples
            List<Person> people = new List<Person> {
                { ID = 1, IDRole = 1, LastName = "Anderson", FirstName = "Brad"},
                { ID = 2, IDRole = 2, LastName = "Gray", FirstName = "Tom"}
            };

            List<Role> roles = new List<Role> {
                { ID = 1, RoleDescription = "Manager" },
                { ID = 2, RoleDescription = "Developer" }
            };
            #endregion

            #region Listing 1-1
            //var query = from p in people
            //            where p.ID == 1
            //            select new { p.FirstName, p.LastName };

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-2
            //var query = people
            //            .Where(p => p.ID == 1)
            //            .Select(p => new { p.FirstName, p.LastName } );

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-3
            //string s = "This is a test";
            //Console.WriteLine(s.SpaceToUnderscore());
            //return;
            #endregion

            #region     Listing 1-4
            //Func<Person, bool> filter = delegate(Person p) { return p.ID == 1; };
            //var query = people
            //            .Where(filter)
            //            .Select(p => new { p.FirstName, p.LastName } );

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-6
            // The standard object creation and initialization
            //Person p1 = new Person();
            //p1. FirstName = "Brad";
            //p1.LastName = "Anderson";
            //ObjectDumper.Write(p1);

            //Person p2 = new Person { FirstName="Tom", LastName = "Gray" };
            //ObjectDumper.Write(p2);
            #endregion

            #region Listing 1-10

            //var query = people
            //            .Where (p => p.ID == 1)
            //            .Select( p => new { p.FirstName, p.LastName } )
            //            .ToArray();

            //ObjectDumper.Write(query);


            //people[0].FirstName = "Fabio";

            //ObjectDumper.Write(query);

            #endregion
        }
    }
}
