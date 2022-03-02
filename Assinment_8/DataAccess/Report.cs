using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assinment_8.DataAccess;
using Assinment_8.Models;
using System.Data;
using System.Data.SqlClient;

namespace Assinment_8.DataAccess
{
    internal class Report : IDataAccess<Employee, string>
    {
        SqlConnection Conn;
         SqlCommand Cmd;
        public Report()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }

       
        void IDataAccess<Employee, string>.GetAllEmployeesByDeptName(String id)
        {

            List<EmpDept> empDept = new List<EmpDept>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Capacity , Location ,Email From Department Left Join Employee on Department.DeptNo = Employee.DeptNo";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    // Console.WriteLine($"{Reader["EmpName"]} and {Reader["DeptName"]}");
                    empDept.Add(
                          new EmpDept()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              Email = Reader["Email"].ToString(),
                              Location = Reader["Location"].ToString(),
                              DeptName = Reader["DeptName"].ToString(),
                              Capacity = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
                Conn.Close();
                var EmpployeesByDeptName = empDept.Where(e => e.DeptName == id)
                            .Select(e => e);
                foreach (var Emp in EmpployeesByDeptName)
                {

                    Console.WriteLine($"\t{Emp.EmpName} is from department {Emp.DeptName}");

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }

        void IDataAccess<Employee, string>.GetAllEmployeesByLocation(string id)
        {
            List<EmpDept> empDept = new List<EmpDept>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Capacity , Location ,Email From Department Left Join Employee on Department.DeptNo = Employee.DeptNo";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    // Console.WriteLine($"{Reader["EmpName"]} and {Reader["DeptName"]}");
                    empDept.Add(
                          new EmpDept()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              Email = Reader["Email"].ToString(),
                              Location = Reader["Location"].ToString(),
                              DeptName = Reader["DeptName"].ToString(),
                              Capacity = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
                Conn.Close();
                var EmpployeesByDeptName = empDept.Where(e => e.Location == id)
                            .Select(e => e);
                foreach (var Emp in EmpployeesByDeptName)
                {

                    Console.WriteLine($"\t{Emp.EmpName} is from  {Emp.Location}");

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }

        void IDataAccess<Employee, string>.GetAllEmployeesWithMaxSalByDeptName(string id)
        {
            List<EmpDept> empDept = new List<EmpDept>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Capacity , Location ,Email From Department Left Join Employee on Department.DeptNo = Employee.DeptNo";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    // Console.WriteLine($"{Reader["EmpName"]} and {Reader["DeptName"]}");
                    empDept.Add(
                          new EmpDept()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              Email = Reader["Email"].ToString(),
                              Location = Reader["Location"].ToString(),
                              DeptName = Reader["DeptName"].ToString(),
                              Capacity = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
                Conn.Close();
                //var EmpployeesByDeptName = empDept.GroupBy(e=>e.DeptName)
                //            .Select(e=>);
                //foreach (var Emp in EmpployeesByDeptName)
                //{

                //    Console.WriteLine($"\t{Emp.EmpName} is from department {Emp.DeptName}");

                //}
                var deptSal = empDept.GroupBy(e => e.DeptName);
                foreach (var dept in deptSal)
                {
                    var maxSal = dept.Max(e => e.Salary);
                    Console.WriteLine($"The maximum salary of {dept.Key} is {maxSal} ");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }

        void IDataAccess<Employee, string>.GetSumSalaryByDeptName(string id)
        {
            List<EmpDept> empDept = new List<EmpDept>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Capacity , Location ,Email From Department Left Join Employee on Department.DeptNo = Employee.DeptNo";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    // Console.WriteLine($"{Reader["EmpName"]} and {Reader["DeptName"]}");
                    empDept.Add(
                          new EmpDept()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              Email = Reader["Email"].ToString(),
                              Location = Reader["Location"].ToString(),
                              DeptName = Reader["DeptName"].ToString(),
                              Capacity = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
                Conn.Close();
                var deptSal = empDept.GroupBy(e => e.DeptName);

                foreach (var dept in deptSal)
                {
                    var sum = dept.Sum(e => e.Salary);
                    Console.WriteLine($"\nThe sum of salaries of {dept.Key} is {sum}");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }
    }
}
