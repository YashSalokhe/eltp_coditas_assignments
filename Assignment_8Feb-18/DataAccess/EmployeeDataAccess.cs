using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_8Feb_18.Models;
using System.Data;
using System.Data.SqlClient;

namespace Assignment_8Feb_18.DataAccess
{
     public class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public EmployeeDataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }
        IEnumerable<Employee> IDataAccess<Employee, int>.GetAllEmployeesByDeptName(int id)
        {
            Conn.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            
            List<Employee> employee = new List<Employee>();

            Cmd.CommandText = "select * from Employee";
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                Console.WriteLine($"EmpNo: {Reader["EmpNo"]}, EmpName: {Reader["EmpName"]}, Salary: {Reader["Salary"]}, Designation: {Reader["Designation"]}, DeptNo : {Reader["DeptNo"]}");
            }
            Reader.Close();
            return employee;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetAllEmployeesByLocation(int id)
        {
            List<Employee> employee = new List<Employee>();
            return employee;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetAllEmployeesWithMaxSalByDeptName(int id)
        {
            List<Employee> employee = new List<Employee>();
            return employee;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetSumSalaryByDeptName(int id)
        {
            List<Employee> employee = new List<Employee>();
            return employee;
        }
    }
}
