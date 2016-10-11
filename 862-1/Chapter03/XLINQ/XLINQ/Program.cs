using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using System.Xml;
using System.IO;

namespace XLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Listing 3-2
            //XDocument xml = XDocument.Load(@"..\..\People.xml");
            
            //var query = from p in xml.Elements("people").Elements("person")
            //            where (int)p.Element("id") == 1
            //            select p;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Person: {0} {1}",
            //                                        record.Element("firstname").Value, 
            //                                        record.Element("lastname").Value);
            //}

            #endregion

            #region Listing 3-3
            //XElement xml = XElement.Load(@"..\..\People.xml");
            
            //var query = from p in xml.Elements("person")
            //            where (int)p.Element("id") == 1
            //            select p;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Person: {0} {1}",
            //                                        record.Element("firstname"), 
            //                                        record.Element("lastname"));
            //}
            #endregion

            #region Listing 3-4
            //XElement xml = XElement.Load(@"..\..\People.xml");
            
            //var query = from s in xml.Elements("salary").Elements("idperson")
            //            where (int)s.Attribute("year") == 2004
            //            select s;

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Amount: {0}", (string) record.Attribute("salaryyear"));
            //}
            #endregion

            #region Listing 3-5
            //XElement xml = XElement.Load(@"..\..\People.xml");
            
            //var query = from p in xml.Descendants("person")
            //            join s in xml.Descendants("idperson")
            //            on (int)p.Element("id") equals (int)s.Attribute("id")
            //            select new {FirstName=p.Element("firstname").Value, 
            //                        LastName=p.Element("lastname").Value,
            //                        Amount=s.Attribute("salaryyear").Value};

            //foreach(var record in query)
            //{
            //    Console.WriteLine("Person: {0} {1}, Salary {2}",record.FirstName,
            //                                                    record.LastName,
            //                                                    record.Amount);
            //}
            #endregion

            #region Listing 3-6
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //var record = xml.Descendants("firstname").First();
            //foreach(var tag in record.Ancestors())
            //    Console.WriteLine(tag.Name);
            #endregion

            #region Listing 3-7
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //IEnumerable<XComment> record = xml.Nodes().OfType<XComment>();
            //foreach(XComment comment in record)
            //    Console.WriteLine(comment);
            #endregion

            #region Listing 3-9
            //XElement xml = XElement.Load(@"..\..\Hello_XLINQ.xml");
            //XNamespace o = "urn:schemas-microsoft-com:office:office";

            //var query = from w in xml.Descendants(o + "Author")
            //            select w;
            //foreach (var record in query)
            //    Console.WriteLine("Author: {0}", (string)record);

            #endregion

            #region Listing 3-10
            //XElement xml = XElement.Load(@"..\..\Hello_XLINQ.xml");
            //XNamespace w = "http://schemas.microsoft.com/office/word/2003/wordml";

            //XElement defaultFonts = xml.Descendants(w + "defaultFonts").First();
            //Console.WriteLine("Default Fonts: {0}", (string)defaultFonts.Attribute(w + "ascii"));
            #endregion

            #region Listing 3-11
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement firstName = xml.Descendants("firstname").First();
            
            //Console.WriteLine("Before <firstname>");
            //foreach(var tag in firstName.ElementsBeforeThis())
            //    Console.WriteLine(tag.Name);

            //Console.WriteLine("");
            //Console.WriteLine("After <firstname>");
            //foreach(var tag in firstName.ElementsAfterThis())
            //    Console.WriteLine(tag.Name);
            #endregion

            #region Listing 3-12
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement firstName = xml.Descendants("firstname").First();
            
            //Console.WriteLine(firstName.Parent);
            #endregion

            #region Listing 3-13
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement firstName = xml.Descendants("firstname").First();
            
            //Console.WriteLine("FirstName tag has attributes: {0}", firstName.HasAttributes);
            //Console.WriteLine("FirstName tag has child elements: {0}", firstName.HasElements);
            //Console.WriteLine("FirstName tag's parent has attributes: {0}", firstName.Parent.HasAttributes);
            //Console.WriteLine("FirstName tag's parent has child elements: {0}", firstName.Parent.HasElements);

            #endregion

            #region Listing 3-14
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement firstName = xml.Descendants("firstname").First();
            
            //Console.WriteLine("Is FirstName tag empty? {0}", firstName.IsEmpty ? "Yes" : "No");

            //XElement idPerson = xml.Descendants("idperson").First();
            
            //Console.WriteLine("Is idperson tag empty? {0}", idPerson.IsEmpty ? "Yes" : "No");

            #endregion

            #region Listing 3-15
            //XDocument xml = XDocument.Load(@"..\..\Hello_XLINQ.xml");

            //Console.WriteLine("Encoding: {0}", xml.Declaration.Encoding);
            //Console.WriteLine("Version: {0}", xml.Declaration.Version);
            //Console.WriteLine("Standalone: {0}", xml.Declaration.Standalone);
            #endregion

            #region Listing 3-16
            //XDocument xml = new XDocument(  new XDeclaration("1.0", "UTF-8", "yes"),
            //                                new XElement("people",
            //                                    new XElement("idperson",
            //                                    new XAttribute("id", 1),
            //                                    new XAttribute("year", 2004),
            //                                    new XAttribute("salaryyear", "10000,0000"))));

            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //xml.Save(sw);
            //Console.WriteLine(sw);
            #endregion

            #region Listing 3-17
            //XNamespace w ="http://schemas.microsoft.com/office/word/2003/wordml";
            //XDocument word = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
            //                                    new XProcessingInstruction("mso-application", "progid=\"Word.Document\""),
            //                                    new XElement(w + "wordDocument",
            //                                        new XAttribute(XNamespace.Xmlns + "w", w.Uri)));
                                                
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //word.Save(sw);
            //Console.WriteLine(sw);

            #endregion

            #region Listing 3-18
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement html = new XElement("HTML",
            //                        new XElement("BODY",
            //                            new XElement("TABLE",
            //                                new XElement("TH", "ID"),
            //                                new XElement("TH", "Full Name"),
            //                                new XElement("TH", "Role"),
            //                                    from p in xml.Descendants("person")
            //                                    join r in xml.Descendants("role") on (int) p.Element("idrole") equals (int) r.Element("id")
            //                                select new  XElement("TR", 
            //                                                new XElement("TD", p.Element("id").Value),
            //                                                new XElement("TD", p.Element("firstname").Value + " " + p.Element("lastname").Value),
            //                                                new XElement("TD", r.Element("roledescription").Value)))));

            //html.Save(@"C:\People.html");

            #endregion

            #region Listing 3-19
//            string doc = @"<people>
//	                        <!-- Person section -->
//	                        <person>
//		                        <id>1</id>
//		                        <firstname>Carl</firstname>
//		                        <lastname>Lewis</lastname>
//		                        <idrole>1</idrole>
//	                        </person>
//                           </people>";
//            XElement xml = XElement.Parse(doc);
//            Console.WriteLine(xml);
            #endregion

            #region Listing 3-20
            //XmlReader reader = XmlReader.Create(@"..\..\People.xml");
            //XDocument xml = XDocument.Load(reader);
            //Console.WriteLine(xml);

            //XElement idperson = xml.Descendants("idperson").Last();
            //idperson.Add(new XElement("idperson",
            //                new XAttribute("id", 1),
            //                new XAttribute("year", 2006),
            //                new XAttribute("salaryyear", "160000,0000")));
            
            //StringWriter sw = new StringWriter();
            //XmlWriter w = XmlWriter.Create(sw);
            //xml.Save(w);
            //w.Close();
            //Console.WriteLine(sw.ToString());

            #endregion

            #region Listing 3-21
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //xml.AddFirst(new XElement("person",
            //                new XElement("id",5),
            //                new XElement("firstname","Tom"),
            //                new XElement("lastname","Cruise"),
            //                new XElement("idrole",1)));
            //Console.WriteLine(xml);
            #endregion

            #region Listing 3-22
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement role = xml.Descendants("role").First();
            //Console.WriteLine("-=-=ORIGINAL-=-=");
            //Console.WriteLine(role);

            //role.SetElement("roledescription", "Actor");
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("-=-=UPDATED-=-=");
            //Console.WriteLine(role);
            #endregion

            #region Listing 3-23
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //XElement role = xml.Descendants("idperson").First();
            //Console.WriteLine("-=-=ORIGINAL-=-=");
            //Console.WriteLine(role);

            //role.SetAttribute("year", "2006");
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("-=-=UPDATED-=-=");
            //Console.WriteLine(role);
            #endregion

            #region Listing 3-24
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //xml.Element("person").ReplaceContent(new XElement("id", 5),
            //                                     new XElement("firstname","Tom"),
            //                                     new XElement("lastname","Cruise"),
            //                                     new XElement("idrole",1));
            //Console.WriteLine(xml);
            #endregion

            #region Listing 3-25
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //xml.Descendants("idperson").First().Remove();

            //xml.Elements("role").Remove();

            //Console.WriteLine(xml);
            #endregion

            #region Listing 3-26
            //XElement xml = XElement.Load(@"..\..\People.xml");

            //xml.Element("role").RemoveContent();

            //Console.WriteLine(xml);
            #endregion

            #region Listing 3-27
            //PeopleDataContext people = new PeopleDataContext();

            //XElement xml = new XElement("people",
            //                        from p in people.People
            //                        select  new XElement("person",
            //                                    new XElement("id", p.ID),
            //                                    new XElement("firstname", p.FirstName),
            //                                    new XElement("lastname", p.LastName),
            //                                    new XElement("idrole", p.IDRole)));
            //Console.WriteLine(xml);
            #endregion

            #region Listing 3-28
            //xml.Add(new XElement("person",
            //            new XElement("id", 5),
            //            new XElement("firstname", "Tom"),
            //            new XElement("lastname", "Cruise"),
            //            new XElement("idrole", 1)));

            //Console.WriteLine(xml);
            
            //AddPerson(xml, people);
            #endregion
        }

        #region Listing 3-29
        private static void AddPerson(XElement xml, PeopleDataContext peopledb)
        {
            var people = xml.Descendants("person");
            foreach(var person in people)
            {
                var query = from p in peopledb.People
                            where p.ID == (int)person.Element("id")
                            select p;

                if (query.ToList().Count == 0)
                {
                    Person per = new Person();
                    per.FirstName = person.Element("firstname").Value;
                    per.LastName = person.Element("lastname").Value;
                    per.IDRole = (int)person.Element("idrole");
                    peopledb.People.Add(per);
                }
            }

            peopledb.SubmitChanges();
        }
        #endregion
    }
}
