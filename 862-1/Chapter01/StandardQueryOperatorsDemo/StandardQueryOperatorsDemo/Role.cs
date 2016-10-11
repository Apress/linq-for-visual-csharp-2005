using System;
using System.Collections.Generic;
using System.Text;

namespace StandardQueryOperatorsDemo
{
    class Role
    {
        int _id;
        string _roleDescription;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string RoleDescription
        {
            get { return _roleDescription; }
            set { _roleDescription = value; }
        }
    }
}
