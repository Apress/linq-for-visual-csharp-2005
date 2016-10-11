using System;
using System.Collections.Generic;
using System.Text;
using System.Data.DLinq;
using System.Reflection;
using System.Expressions;
using System.Query;

namespace LINQOverDataSet
{
    public class PeopleDataContext : DataContext
    {
        public Table<Person> People;
        public Table<Role> Roles;
        public Table<Salary> Salaries;

        public PeopleDataContext(): base("Data Source=.;Initial Catalog=People;Integrated Security=True") {}

        public PeopleDataContext(string connection): base(connection) {}

        [InsertMethod]
        public void InsertRole(Role r)
        {
            this.ExecuteCommand("exec uspInsertRole @description={0}", r.RoleDescription);
        }

        [UpdateMethod]
        public void UpdateRole(Role oldRole, Role newRole)
        {
            if (oldRole.RoleDescription != newRole.RoleDescription)
            {
                int iRowsAffected = this.ExecuteCommand("exec uspUpdateRole @id={0}, @description={1}", 
                                                                        newRole.ID,
                                                                        newRole.RoleDescription);
                if (iRowsAffected < 1)
                    throw new OptimisticConcurrencyException();
            }
        }

        [DeleteMethod]
        public void DeleteRole(Role r)
        {
            this.ExecuteCommand("exec uspDeleteRole @id={0}", r.ID);
        }

        [StoredProcedure(Name="uspCountPerson")]
        public int UspCountPerson() 
        {
            MethodInfo info = (MethodInfo)(MethodInfo.GetCurrentMethod());
            StoredProcedureResult result = this.ExecuteStoredProcedure(info);
            return result.ReturnValue.Value;
        }

        [StoredProcedure(Name="uspGetRoleDescription")]
        public StoredProcedureResult<Role> UspGetRoleDescription
                                                    ([Parameter(DBType="VarChar(50)")] string description) 
        {
            return this.ExecuteStoredProcedure<Role>(
                                                    ((MethodInfo)(MethodInfo.GetCurrentMethod())), description);
        }

        [StoredProcedure(Name="uspGetRolesAndPeople")]
        public StoredProcedureMultipleResult UspGetRolesAndPeople() 
        {
            return ((StoredProcedureMultipleResult)(this.ExecuteStoredProcedure(
                                                    ((MethodInfo)(MethodInfo.GetCurrentMethod())))));
        }

        [StoredProcedure(Name="uspGetTotalSalaryAmountPerYear")]
        public int UspGetTotalSalaryAmountPerYear(
            [Parameter(DBType="Int")] System.Nullable<int> year, 
            [Parameter(DBType="Money")] ref System.Nullable<decimal> amount) 
        {
            MethodInfo info = (MethodInfo)(MethodInfo.GetCurrentMethod());
            StoredProcedureResult result = this.ExecuteStoredProcedure(info, year, amount);
            amount = ((System.Nullable<decimal>)(result.GetParameterValue(1)));
            return result.ReturnValue.Value;
        }

        [Function(Name="[dbo].[udfGetInitials]")]
        public string UdfGetInitials(System.Nullable<int> id) 
        {
            MethodCallExpression mc = Expression.Call(((MethodInfo)(MethodInfo.GetCurrentMethod())), Expression.Constant(this), new Expression[] {
            Expression.Constant(id, typeof(System.Nullable<int>))});
            return Sequence.Single(this.CreateQuery<string>(mc));
        }
    }

    [Table(Name="Person")]
    public class Person
    {
        private int _ID;
        private int _IDRole;
        private string _lastName;
        private string _firstName;

        [Column(Name="FirstName", 
                Storage="_firstName", 
                DBType="nvarchar NOT NULL")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Column(Name="LastName", 
                Storage="_lastName", 
                DBType="nvarchar NOT NULL")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [Column(Name="IDRole", 
                Storage="_IDRole", 
                DBType="int NOT NULL")]
        public int IDRole
        {
            get { return _IDRole; }
            set { _IDRole = value; }
        }

        [Column(Name="ID", 
                Storage="_ID", 
                DBType="int NOT NULL IDENTITY", 
                Id=true, 
                AutoGen=true)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }

    [Table(Name="Role")]
    public class Role
    {
        private int _ID;
        private string _Description;
        private EntitySet<Person> _People;

        [Column(	Name="ID", Storage="_ID", 
                    DBType="int NOT NULL IDENTITY", 
                    Id=true, 
                    AutoGen=true)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Column(	Name="RoleDescription", 
                    Storage="_Description", 
                    DBType="nvarchar NOT NULL")]
        public string RoleDescription
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }

    [Table(Name="Salary")]
    public class Salary
    {
        private int _ID;
        private int _Year;
        private decimal _Salary;

        [Column(Name="IDPerson", Storage="_ID", DBType="int NOT NULL")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Column(Name="Year", Storage="_Year", DBType="int NOT NULL")]
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        [Column(Name="SalaryYear", Storage="_Salary", DBType="money NOT NULL")]
        public decimal SalaryYear
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
    }
}
