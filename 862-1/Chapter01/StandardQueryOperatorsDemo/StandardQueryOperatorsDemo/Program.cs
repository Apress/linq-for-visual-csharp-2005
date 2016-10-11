using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;

using System.Reflection;


namespace StandardQueryOperatorsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Data Region
            List<Person> people = new List<Person> {
                { ID = 1, IDRole = 1, LastName = "Anderson", FirstName = "Brad"},
                { ID = 2, IDRole = 2, LastName = "Gray", FirstName = "Tom"},
                { ID = 3, IDRole = 2, LastName = "Grant", FirstName = "Mary"},
                { ID = 4, IDRole = 3, LastName = "Cops", FirstName = "Gary"}
            };

            List<Role> roles = new List<Role> {
                { ID = 1, RoleDescription = "Manager" },
                { ID = 2, RoleDescription = "Developer" }
            };

            List<Salary> salaries = new List<Salary> {
                { IDPerson = 1, Year = 2004, SalaryYear = 10000.00 },
                { IDPerson = 1, Year = 2005, SalaryYear = 15000.00 },
                { IDPerson = 1, Year = 2005, SalaryYear = 15000.00 }
            };
            #endregion

            #region Listing 1-12
            //var query = from p in people
            //            where p.FirstName == "Brad"
            //            select p;

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-13
            //var query = people
            //            .Where(( p, index) => p.IDRole == index);

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-14
            //var query = from p in people
            //            select p;

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-15
            //var query = people
            //            .Select(( p, index) => new { Position = index, p.FirstName, p.LastName });

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-16
            //var query = from p in people
            //            where p.ID == 1
            //            from r in roles
            //            where r.ID == p.IDRole
            //            select new { p.FirstName, p.LastName, r.RoleDescription };

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-17
            //var query = people
            //            .Where(p => p.ID == 1)
            //            .SelectMany(p => roles
            //                            .Where(r => r.ID == p.ID)
            //                            .Select(r => new {p.FirstName, p.LastName, r.RoleDescription}));

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-18
            //var query = from p in people 
            //            join r in roles on p.IDRole equals r.ID
            //            select p;

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-19
            //var query = from p in people 
            //            join r in roles on p.IDRole equals r.ID into pr
            //            select pr;

                        //from r in pr.DefaultIfEmpty()
                        //select new { p.FirstName, p.LastName, 
                        //             RoleDescription = r == null ? "No Role" : r.RoleDescription };

            //ObjectDumper.Write(query,1);
            #endregion

            #region Listing 1-20
            //var query = from m in typeof(int).GetMethods()
            //            select m.Name;

            //ObjectDumper.Write(query);

            //Console.WriteLine("-=-=-=-=-=-=-=-=-=");
            //Console.WriteLine("After the GroupBy");
            //Console.WriteLine("-=-=-=-=-=-=-=-=-=");

            //var q = from m in typeof(int).GetMethods()
            //        group m by m.Name into gb
            //        select new {Name = gb.Key};

            //ObjectDumper.Write(q);
            #endregion

            #region Listing 1-21
            //var q = from m in typeof(int).GetMethods()
            //        group m by m.Name into gb
            //        select new {Name = gb.Key, Overloads = gb.Count()};

            //ObjectDumper.Write(q);

            #endregion

            #region Listing 1-22
            //string[] dictionary = new string[] {"F:Apple", "F:Banana", 
            //                                    "T:House", "T:Phone", 
            //                                    "F:Cherry", "T:Computer"};
            //var query = dictionary.GroupBy(d => d, new MyComparer());

            //ObjectDumper.Write(query, 1);
            #endregion

            #region Listing 1-23
            //var q = from m in typeof(int).GetMethods()
            //        orderby m.Name
            //        group m by m.Name into gb
            //        select new {Name = gb.Key};

            //ObjectDumper.Write(q);
            #endregion

            #region Listing 1-24
            //var query = from p in people
            //            orderby p.FirstName, p.LastName
            //            select p;

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-25
            //string[] dictionary = new string[] { "Apple", "_Banana", "Cherry" };
            //var query = dictionary.OrderBy(w => w, new MyOrderingComparer());

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-26
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var query = numbers.Sum();

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-27
            //var query = from p in people
            //            join s in salaries on p.ID equals s.IDPerson
            //            select new { p.FirstName, p.LastName, s.SalaryYear };

            //var querySum = from q in query
            //               group q by q.LastName into gp
            //               select new {LastName = gp.Key, TotalSalary = gp.Sum(q => q.SalaryYear) };

            #endregion

            #region Listing 1-28
            //var query = from p in people
            //            join s in salaries on p.ID equals s.IDPerson
            //            where p.ID == 1
            //            select s.SalaryYear;

            //Console.WriteLine("Minimum Salary:");
            //ObjectDumper.Write(query.Min());

            //Console.WriteLine("Maximum Salary:");
            //ObjectDumper.Write(query.Max());

            #endregion

            #region Listing 1-29
            //var query = from p in people
            //            join s in salaries on p.ID equals s.IDPerson
            //            where p.ID == 1
            //            select s.SalaryYear;

            //Console.WriteLine("Average Salary:");
            //ObjectDumper.Write(query.Average());

            #endregion

            #region Listing 1-30
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var query = numbers.Aggregate((a,b) => a * b);

            //ObjectDumper.Write(query);

            #endregion

            #region Listing 1-31
            //int[] numbers = { 9, 3, 5, 4, 2, 6, 7, 1, 8 };
            //var query = numbers.Aggregate(5, (a,b) => ( (a < b) ? (a * b) : a));

            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-32
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var query = numbers.Take(5);
            //ObjectDumper.Write(query);
            //Console.Write("Press Enter key to see the other elements...");
            //Console.ReadLine();
            //var query2 = numbers.Skip(5);
            //ObjectDumper.Write(query2);
            #endregion

            #region Listing 1-33
            //int[] numbers = { 9, 3, 5, 4, 2, 6, 7, 1, 8 };
            //var query = numbers.TakeWhile(( n, index) => n >= index);
            //ObjectDumper.Write(query);
            //Console.Write("Press Enter key to see the other elements...");
            //Console.ReadLine();
            //var query2 = numbers.SkipWhile(( n, index) => n >= index);
            //ObjectDumper.Write(query2);
            #endregion

            #region Listing 1-34
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] moreNumbers = { 10, 11, 12, 13 };

            //var query = numbers.Concat(moreNumbers);
            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-35
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var query = numbers.First();
            //Console.WriteLine("The first element in the sequence");
            //ObjectDumper.Write(query);
            //query = numbers.Last();
            //Console.WriteLine("The last element in the sequence");
            //ObjectDumper.Write(query);
            //Console.WriteLine("The first even element in the sequence");
            //query = numbers.First(n => n % 2 == 0);
            //ObjectDumper.Write(query);
            //Console.WriteLine("The last even element in the sequence");
            //query = numbers.Last(n => n % 2 == 0);
            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-36
            //int[] numbers = { 1, 3, 5, 7, 9 };
            //var query = numbers.FirstOrDefault(n => n % 2 == 0);
            //Console.WriteLine("The first even element in the sequence");
            //ObjectDumper.Write(query);
            //Console.WriteLine("The last odd element in the sequence");
            //query = numbers.LastOrDefault(n => n % 2 == 1);
            //ObjectDumper.Write(query);

            #endregion

            #region Listing 1-37
            //int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            //var query = numbers.Single(n => n > 8);
            //ObjectDumper.Write(query);

            #endregion

            #region Listing 1-38
            //int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            //var query = numbers.SingleOrDefault(n => n > 9);
            //ObjectDumper.Write(query);

            #endregion

            #region Listing 1-39
            //int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            //var query = numbers.ElementAt(4);
            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-39
            //int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            //var query = numbers.ElementAtOrDefault(9);
            //ObjectDumper.Write(query);
            #endregion

            #region Listing 1-40
            //IEnumerable<Person> p = Sequence.Empty<Person>();
            //ObjectDumper.Write(p);
            #endregion

            #region Listing 1-41
            //ObjectDumper.Write(Sequence.Range(1, 10));
            #endregion

            #region Listing 1-42
            //IEnumerable<Person> p = Sequence.Repeat(people[0], 10);
            //ObjectDumper.Write(p);
            #endregion

            #region Listing 1-43
            //int[] numbers = { 2, 6, 24, 56, 102 };
            //Console.WriteLine("Are those all even numbers?");
            //ObjectDumper.Write(numbers.All(e => e % 2 == 0) ? "Yes, they are" : "No, they aren't");
            #endregion

            #region Listing 1-44
            //int[] numbers = { 2, 6, 24, 56, 102 };
            //Console.WriteLine("Is there at least one odd number?");
            //ObjectDumper.Write(numbers.Any(e => e % 2 == 1) ? "Yes, there is" : "No, there isn't");
            #endregion

            #region Listing 1-45
            //int[] numbers = { 2, 6, 24, 56, 102 };
            //Console.WriteLine("Is there the number 102?");
            //ObjectDumper.Write(numbers.Contains(102) ? "Yes, there is" : "No, there isn't");
            #endregion

            #region Listing 1-46
            //int[] sequence1 = {1, 2, 3, 4, 5};
            //int[] sequence2 = {1, 2, 3, 4, 5};

            //Console.WriteLine("Are those sequence equal?");
            //ObjectDumper.Write(sequence1.EqualAll(sequence2) ? "Yes, they are" : "No, they aren't");

            //int[] sequence3 = {1, 2, 3, 4, 5};
            //int[] sequence4 = {5, 4, 3, 2, 1};

            //Console.WriteLine("Are those sequence equal?");
            //ObjectDumper.Write(sequence3.EqualAll(sequence4) ? "Yes, they are" : "No, they aren't");

            #endregion

            #region Listing 1-47
            //int[] numbers = {1, 1, 2, 3, 3};
            //ObjectDumper.Write(numbers.Distinct());
            #endregion

            #region Listing 1-48
            //int[] numbers = {1, 1, 2, 3, 3};
            //int[] numbers2 = {1, 3, 3, 4};
            //ObjectDumper.Write(numbers.Intersect(numbers2));
            #endregion

            #region Listing 1-49
            //int[] numbers = {1, 1, 3, 3};
            //int[] numbers2 = {1, 2, 3, 4};
            //ObjectDumper.Write(numbers.Union(numbers2));

            #endregion

            #region Listing 1-50
            //int[] numbers = {1, 2, 3, 4};
            //int[] numbers2 = {1, 1, 3, 3};
            //ObjectDumper.Write(numbers.Except(numbers2));

            #endregion

            #region Listing 1-51
            //object[] sequence = {1, "Hello", 2.0};
            //ObjectDumper.Write(sequence.OfType<double>());
            #endregion

            #region Listing 1-52
            //object[] doubles = {1.0, 2.0, 3.0};
            //IEnumerable<double> d = doubles.Cast<double>();
            //ObjectDumper.Write(d);
            #endregion

            #region Listing 1-53
            //var query = from p in people
            //            where p.LastName.Length == 4
            //            select p.LastName;

            //string[] names = query.ToArray();
            
            //for(int i=0; i<names.Length; i++)
            //    Console.WriteLine(names[i]);
            #endregion

            #region Listing 1-54
            //var query = from p in people
            //            where p.LastName.Length == 4
            //            select p.LastName;

            //List<string> names = query.ToList<string>();
            //ObjectDumper.Write(names);
            #endregion

            #region Listing 1-55
            //var q = from m in typeof(int).GetMethods()
            //        group m by m.Name into gb
            //        select gb;

            //Dictionary<string, int> d = q.ToDictionary(k => k.Key, k => k.Count());

            #endregion

            #region Listing 1-56
            IEnumerable<Salary> q = from p in people
                    where p.ID == 1
                    from s in salaries
                    where s.IDPerson == p.ID
                    select s;

            Lookup<string, Salary> d = q.ToLookup(k => k.Year.ToString(), k => k);
            #endregion
        }
    }

    //public class MyComparer : IEqualityComparer<string>
    //{
    //    public bool Equals(string x, string y) {
    //        return (x.Substring(0,2)) == (y.Substring(0,2));
    //    }

    //    public int GetHashCode(string obj) {
    //        return (obj.Substring(0,2)).GetHashCode();
    //    }
    //}

    //public class MyOrderingComparer : IComparer<string>
    //{
    //    public int Compare(string x, string y)
    //    {
    //        x = x.Replace("_",string.Empty);
    //        y = y.Replace("_",string.Empty);

    //        return string.Compare(x, y);
    //    }
    //}
}
