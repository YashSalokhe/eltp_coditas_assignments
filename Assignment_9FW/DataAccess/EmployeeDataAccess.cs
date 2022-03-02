using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Assignment_9FW.Models;

namespace Assignment_9FW.DataAccess
{
    public class EmployeeDataAccess : IDataAccess<Employee> 
    {
        SqlConnection Conn;
        SqlDataAdapter AdEmp = null;
        DataSet Ds = null;
        public EmployeeDataAccess()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
            SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
             DataSet Ds = new DataSet();
            AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdEmp.Fill(Ds, "Employee");
        }

        void IDataAccess<Employee>.Delete()
        {
           // SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
           // DataSet Ds = new DataSet();
           // AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
           // AdEmp.Fill(Ds, "Employee");

            Console.WriteLine("Enter empno to delete");
            int no = int.Parse(Console.ReadLine());

            DataRow DrFind = Ds.Tables["Employee"].Rows.Find(no);
            DrFind.Delete();
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdEmp);
            AdEmp.Update(Ds, "Employee");
        }

        void IDataAccess<Employee>.Insert()
        {
           // SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
            //DataSet Ds = new DataSet();

            //AdEmp.Fill(Ds, "Employee");
            DataRow DrNew = Ds.Tables["Employee"].NewRow();

            Console.WriteLine("Enter Employee No");
            int Empno = int.Parse(Console.ReadLine());
            DrNew["EmpNo"] = Empno;

            Console.WriteLine("Enter Employee name");
            string name = Console.ReadLine();
            DrNew["EmpName"] = name;

            Console.WriteLine("Enter Salary");
            int Salary = int.Parse(Console.ReadLine());
            DrNew["Salary"] = Salary;

            Console.WriteLine("Enter Dept number");
            int DeptNo = int.Parse(Console.ReadLine());
            DrNew["DeptNo"] = DeptNo;

            Console.WriteLine("Enter Designation");
            string Designation = Console.ReadLine();
            DrNew["Designation"] = Designation;


            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();
            DrNew["Email"] = Email;


            Ds.Tables["Employee"].Rows.Add(DrNew);
            SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdEmp);
            AdEmp.Update(Ds, "Employee");
        }

        void IDataAccess<Employee>.Read()
        {
           //SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
           // DataSet Ds = new DataSet();
           // AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
           // AdEmp.Fill(Ds, "Employee");
            DataRowCollection dataRows = Ds.Tables["Employee"].Rows;

            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["EmpNo"]}     {row["EmpName"]}    {row["DeptNo"]}  {row["Designation"]}       {row["Salary"]}  {row["Email"]} ");
            }
        }
    

        void IDataAccess<Employee>.Update()
        {
            //SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
            //DataSet Ds = new DataSet();
            //AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //AdEmp.Fill(Ds, "Employee");

            Console.WriteLine("Enter empno ypu want to update");
            int no = int.Parse(Console.ReadLine());

            DataRow DrFind = Ds.Tables["Employee"].Rows.Find(no);

            Console.WriteLine("Enter updated name");
            string Empname = Console.ReadLine();
            DrFind["EmpName"] = Empname;

            Console.WriteLine("Enter updated Salary");
            int Salary = int.Parse(Console.ReadLine());
            DrFind["Salary"] = Salary;

            Console.WriteLine("Enter updated Dept number");
            int DeptNo = int.Parse(Console.ReadLine());
            DrFind["DeptNo"] = DeptNo;

            Console.WriteLine("Enter updated Designation");
            string Designation = Console.ReadLine();
            DrFind["Designation"] = Designation;


            Console.WriteLine("Enter updated Email");
            string Email = Console.ReadLine();
            DrFind["Email"] = Email;

            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdEmp);
            AdEmp.Update(Ds, "Employee");
        }
    }
}
