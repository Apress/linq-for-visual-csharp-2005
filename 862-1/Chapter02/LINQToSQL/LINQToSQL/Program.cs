using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using System.Transactions;

namespace LINQToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Listing 2-2
            //PeopleDataContext people = new PeopleDataContext();

            //var query = from p in people.People
            //            from s in people.Salaries
            //            where p.ID == s.ID
            //            select new { p.LastName, p.FirstName, s.Year, s.SalaryYear };

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Name: {0}, {1} - Year: {2}", record.LastName, record.FirstName, record.Year);
            //    Console.WriteLine("Salary: {0}", record.SalaryYear);
            //}
            
            #endregion

            #region Listing 2-3
            //PeopleDataContext people = new PeopleDataContext();
            
            //people.Log = Console.Out;

            //var query = from p in people.People
            //            from s in people.Salaries
            //            where p.ID == s.ID
            //            select new { p.LastName, p.FirstName, s.Year, s.SalaryYear };

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Name: {0}, {1} - Year: {2}", record.LastName, record.FirstName, record.Year);
            //    Console.WriteLine("Salary: {0}", record.SalaryYear);
            //}
            #endregion

            #region Listing 2-4
            //PeopleDataContext people = new PeopleDataContext();
            
            //var query = from p in people.People
            //            from s in people.Salaries
            //            where p.ID == s.ID
            //            select new { p.LastName, p.FirstName, s.Year, s.SalaryYear };

            //Console.WriteLine(people.GetQueryText(query));
            //Console.WriteLine();

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Name: {0}, {1} - Year: {2}", record.LastName, record.FirstName, record.Year);
            //    Console.WriteLine("Salary: {0}", record.SalaryYear);
            //}

            //Person person = new Person();
            //person.IDRole = 1;
            //person.FirstName = "From";
            //person.LastName = "Code";
            
            //people.People.Add(person);

            //Console.WriteLine();
            //Console.WriteLine(people.GetChangeText());
            #endregion

            #region Listing 2-5
            //PeopleDataContext people = new PeopleDataContext();
            
            //Person person = new Person();
            //person.IDRole = 1;
            //person.FirstName = "From";
            //person.LastName = "Code";
            
            //people.People.Add(person);
            //people.SubmitChanges();

            //var query = from p in people.People
            //            select p;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Name: {0}, {1}", record.LastName, record.FirstName);
            //}
            #endregion

            #region Listing 2-6
            //PeopleDataContext people = new PeopleDataContext();

            //var person = people.People.Single(p => p.ID == 5);
            
            //person.FirstName = "Name";
            //person.LastName = "Modified";
            
            //Console.WriteLine(people.GetChangeText());

            //people.SubmitChanges();
            #endregion

            #region Listing 2-7
            //PeopleDataContext people = new PeopleDataContext();

            //Person person = new Person();
            //person.ID = 5;

            //people.People.Remove(person);

            //Console.WriteLine(people.GetChangeText());

            //people.SubmitChanges();
            #endregion

            #region Listing 2-10
            //PeopleDataContext people = new PeopleDataContext();

            //var query = from p in people.People
            //            where p.ID == 1
            //            select p;

            //people.Log = Console.Out;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Full Name: {0} {1} Role: {2}", record.FirstName, 
            //                                                      record.LastName, 
            //                                                      record.Role.RoleDescription);
            //}
            #endregion

            #region Listing 2-11
            //PeopleDataContext people = new PeopleDataContext();

            //people.Log = Console.Out;

            //Role role = people.Roles.Single(r => r.ID == 1);
             
            //Person person = new Person();
            //person.FirstName = "From";
            //person.LastName = "Relationship";
            //role.People.Add(person);

            //people.SubmitChanges();
            #endregion

            #region Listing 2-12
            //PeopleDataContext people = new PeopleDataContext();

            //people.Log = Console.Out;

            //Role role = new Role();
            //role.RoleDescription = "Administrator";

            //Person person = new Person();
            //person.FirstName = "From";
            //person.LastName = "Code";

            //role.People.Add(person);
            //people.Roles.Add(role);

            //people.SubmitChanges();

            //Role admin = people.Roles.Single(r => r.ID == role.ID);
            //people.Roles.Remove(admin);
            //people.SubmitChanges();

            #endregion

            #region Listing 2-13
            //PeopleDataContext people = new PeopleDataContext();

            //Person p = people.People.Single(person => person.ID == 1);

            //p.LastName = "Optimistic";
            //p.FirstName = "Concurrency";

            //Console.ReadLine();
            //people.SubmitChanges();
            #endregion

            #region Listing 2-13/b
            //PeopleDataContext people = new PeopleDataContext();

            //Person p = people.People.Single(person => person.ID == 1);

            //p.LastName = "Optimistic";
            //p.FirstName = "Concurrency";

            //try
            //{
            //    people.SubmitChanges(ConflictMode.ContinueOnConflict);
            //}
            //catch(OptimisticConcurrencyException oce)
            //{
            //    oce.Resolve(RefreshMode.KeepChanges);
            //}
            #endregion

            #region Listing 2-14
            //PeopleDataContext people = new PeopleDataContext();

            //using (TransactionScope t = new TransactionScope())
            //{
            //    Person p = people.People.Single(person => person.ID == 1);

            //    p.LastName = "Pessimistic";
            //    p.FirstName = "Concurrency";

            //    Console.ReadLine();

            //    people.SubmitChanges();

            //    t.Complete();
            //}

            #endregion

            #region Listing 2-15
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;

            //Role r = new Role();
            //r.RoleDescription = "Integration with old ADO.NET apps";
            //people.Roles.Add(r);

            //people.Connection.Open();
            //people.LocalTransaction = people.Connection.BeginTransaction();

            //try
            //{
            //    people.SubmitChanges();
            //    people.LocalTransaction.Commit();
            //    people.AcceptChanges();
            //}
            //catch(Exception ex)
            //{
            //    people.LocalTransaction.Rollback();
            //    people.RejectChanges();
            //    throw ex;
            //}
            //finally
            //{
            //    if (people.Connection.State == System.Data.ConnectionState.Open)
            //        people.Connection.Close();

            //    people.LocalTransaction = null;
            //}
            #endregion

            #region Listing 2-16
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;

            //Role r = new Role();
            //r.RoleDescription = "By SP";
            //people.Roles.Add(r);

            //people.SubmitChanges();
            #endregion

            #region Listing 2-17
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;

            //Role r = people.Roles.Single(role => role.ID == 1);
            //r.RoleDescription = "By Update stored procedure";
            
            //people.SubmitChanges();
            #endregion

            #region Listing 2-18
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;

            //var query = people.Roles.Where(role => role.RoleDescription == "By SP")
            //                        .Select(role => role);
            
            //foreach (Role r in query)
            //    people.Roles.Remove(r);
            
            //people.SubmitChanges();
            #endregion

            #region Listing 2-19
            //PeopleDataContext people = new PeopleDataContext();

            //Console.WriteLine("Person count = {0}", people.UspCountPerson());
            #endregion

            #region Listing 2-20
            //PeopleDataContext people = new PeopleDataContext();

            //foreach(Role r in people.UspGetRoleDescription("M%"))
            //{
            //    Console.WriteLine("Role: {0} {1}", r.ID.ToString(), r.RoleDescription);
            //}
            #endregion

            #region Listing 2-21
            //PeopleDataContext people = new PeopleDataContext();
            //StoredProcedureMultipleResult results = people.UspGetRolesAndPeople();

            //var query = from p in results.GetResults<Person>()
            //            from r in results.GetResults<Role>()
            //            where ((p.IDRole == r.ID) && p.ID == 1)
            //            select new {p.FirstName, p.LastName, r.RoleDescription};

            //foreach (var record in query)
            //{
            //    Console.WriteLine("Person: {0} {1} - Role: {2}", record.FirstName, record.LastName, record.RoleDescription);
            //}
            #endregion

            #region Listing 2-22
            //PeopleDataContext people = new PeopleDataContext();
            
            //decimal? total = 0;
            //int year = 2004;

            //people.UspGetTotalSalaryAmountPerYear(year, ref total);

            //Console.WriteLine(total.ToString());
            #endregion

            #region Listing 2-23
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;
            
            //var query = from p in people.People
            //            select new {p.ID, Initials = people.UdfGetInitials(p.ID)};

            //foreach(var record in query)
            //    Console.WriteLine("PersonID: {0} - Initials: {1}", record.ID, record.Initials);

            #endregion

            #region Listing 2-24
            //PeopleDataContext people = new PeopleDataContext("Data Source=.;Initial Catalog=PeopleFromCode;Integrated Security=True");

            //if (people.DatabaseExists())
            //    people.DeleteDatabase();

            //people.CreateDatabase();
            #endregion

            #region Listing 2-25
            //PeopleDataContext people = new PeopleDataContext();
            //people.Log = Console.Out;

            //var query = from r in people.Roles
            //            select r;

            //foreach (var role in query)
            //{
            //    foreach(var person in role.People)
            //    {
            //        Console.WriteLine("Person: {0} {1}", person.FirstName, person.LastName);
            //    }
            //}
            #endregion

            #region Listing 2-25/bis
            PeopleDataContext people = new PeopleDataContext();
            people.Log = Console.Out;

            var query = (from r in people.Roles
                        select r).Including(r => r.People);

            foreach (var role in query)
            {
                foreach(var person in role.People)
                {
                    Console.WriteLine("Person: {0} {1}", person.FirstName, person.LastName);
                }
            }

            #endregion
        }
    }
}
