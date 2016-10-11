using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using System.Data;

namespace LINQOverDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Listing 2-26
            //dsPeople ds = new dsPeople();

            //PeopleDataContext people = new PeopleDataContext();

            //var q = from role in people.Roles
            //            select role;

            //ds.Role.LoadSequence(q);
            #endregion

            #region Listing 2-27
            //var query = from r in ds.Role
            //             where r.ID == 1
            //             select r;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Role: {0} {1}", record.ID, record.RoleDescription);
            //}
            #endregion

            #region Listing 2-28
            PeopleDataContext people = new PeopleDataContext();

            var q = from p in people.People
                    select p;

            DataSet ds = new DataSet("People");
            ds.Tables.Add(q.ToDataTable());
            #endregion

            #region Listing 2-29
            DataTable dtPerson = ds.Tables[0];
            var person = dtPerson.ToQueryable();

            var query = from p in person
                        where p.Field<string>("LastName") == "Ferracchiati"
                        select p;

            foreach(var record in query)
            {
                Console.WriteLine("Person: {0} {1}",
                                                    record.Field<string>("FirstName"), 
                                                    record.Field<string>("LastName"));
            }
            #endregion
        }
    }
}
