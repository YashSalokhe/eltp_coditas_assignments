using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_11.Models;

namespace Assignment_11.DataAccess
{
    internal class EmployeeDataAccess : IDataAccess<Employee,int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public EmployeeDataAccess()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }

       async Task<IEnumerable<Employee>> IDataAccess<Employee, int>.GetEmpDataAsync()
        {
            try
            {
                List<Employee> emps = new List<Employee>();
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Employee";
                var EmpData = await Cmd.ExecuteReaderAsync();
                //var r = EmpData;
                while (EmpData.Read())
                {
                    emps.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(EmpData["EmpNo"]),
                        EmpName = EmpData["EmpName"].ToString(),
                        Salary = Convert.ToInt32(EmpData["Salary"]),
                        Designation = EmpData["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(EmpData["DeptNo"]),
                        Email = EmpData["Email"].ToString(),
                    });
                }
                EmpData.Close();
                Conn.Close();
                return Task.FromResult(emps).Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occured {ex.Message}");
                return null;
            }

        }

       async Task IDataAccess<Employee, int>.Create(Employee entity)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Employee Values({entity.EmpNo}, '{entity.EmpName}', {entity.Salary}, '{entity.Designation}', {entity.DeptNo}, '{entity.Email}')";
                int res = await Cmd.ExecuteNonQueryAsync(); //executes the sql query and returns number of rows affected
                if (res == 0)
                {
                    Console.WriteLine("Employee cannot be added\n");
                }
                else
                {
                    Console.WriteLine("Employee added sucessfully");
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

       async Task<int> IDataAccess<Employee, int>.Delete(int id)
        {
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete From Employee where EmpNo=@EmpNo";
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;
                Cmd.Parameters.Add(pEmpNo);
                int res = await Cmd.ExecuteNonQueryAsync();

                Conn.Close();
                return res;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 0;
                throw ex;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 0;
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

       async Task IDataAccess<Employee, int>.Update(Employee entity, int id)
        {
            Employee employee = new Employee();
            try
            {
                if (id == entity.EmpNo)
                {
                    Conn.Open();
                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Employee Set EmpName=@EmpName, Salary=@Salary, Designation=@Designation, DeptNo=@DeptNo, Email=@Email where EmpNo=@EmpNo";

                    SqlParameter pEmpNo = new SqlParameter();
                    pEmpNo.ParameterName = "@EmpNo";
                    pEmpNo.SqlDbType = SqlDbType.Int;
                    pEmpNo.Direction = ParameterDirection.Input;
                    pEmpNo.Value = id;

                    SqlParameter pEmpName = new SqlParameter();
                    pEmpName.ParameterName = "@EmpName";
                    pEmpName.SqlDbType = SqlDbType.VarChar;
                    pEmpName.Size = 200;
                    pEmpName.Direction = ParameterDirection.Input;
                    pEmpName.Value = entity.EmpName;
                    SqlParameter pSalary = new SqlParameter();
                    pSalary.ParameterName = "@Salary";
                    pSalary.SqlDbType = SqlDbType.Int;
                    pSalary.Direction = ParameterDirection.Input;
                    pSalary.Value = entity.Salary;
                    SqlParameter pDesignation = new SqlParameter();
                    pDesignation.ParameterName = "@Designation";
                    pDesignation.SqlDbType = SqlDbType.VarChar;
                    pDesignation.Size = 100;
                    pDesignation.Direction = ParameterDirection.Input;
                    pDesignation.Value = entity.Designation;
                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = entity.DeptNo;
                    SqlParameter pEmail = new SqlParameter();
                    pEmail.ParameterName = "@Email";
                    pEmail.SqlDbType = SqlDbType.VarChar;
                    pEmail.Size = 300;
                    pEmail.Direction = ParameterDirection.Input;
                    pEmail.Value = entity.Email;

                    Cmd.Parameters.Add(pEmpNo);
                    Cmd.Parameters.Add(pEmpName);
                    Cmd.Parameters.Add(pSalary);
                    Cmd.Parameters.Add(pDesignation);
                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pEmail);
                    int res = await Cmd.ExecuteNonQueryAsync();
                    if (res == 0)
                    {
                        Console.WriteLine("couldn't update employee");
                    }
                    else
                    {
                        Console.WriteLine("Employee updated sucessfully");
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.EmpNo} does not match");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
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
