using System;
using System.Collections.Generic;
using System.Text;

namespace StandardQueryOperatorsDemo
{
    class Person
    {
        int _id;
        int _idRole;
        string _lastName;
        string _firstName;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IDRole
        {
            get { return _idRole; }
            set { _idRole = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
     }

}
