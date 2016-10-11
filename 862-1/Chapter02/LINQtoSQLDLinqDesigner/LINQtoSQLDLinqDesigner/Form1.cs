using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;


namespace LINQtoSQLDLinqDesigner
{
    public partial class Form1 : Form
    {
        private PeopleDataContext db;

        public Form1()
        {
            InitializeComponent();
            db = new PeopleDataContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var query = from r in db.Roles
                        select r;

            dgRole.DataSource = query.ToBindingList();
            dgPerson.DataSource = dgRole.DataSource;
            dgPerson.DataMember = "Persons";
        }
    }
}