using System;
using System.Collections.Generic;
using System.Text;

namespace StandardQueryOperatorsDemo
{
    class Salary
    {
        int _idPerson;
        int _year;
        double _salary;

        public int IDPerson
        {
            get { return _idPerson; }
            set { _idPerson = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public double SalaryYear
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
