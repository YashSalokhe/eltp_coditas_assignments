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
    public class EmployeeDataAccess :  IDataAccessCrud<Employee, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public EmployeeDataAccess()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }
        Employee IDataAccessCrud<Employee, int>.Create(Employee entity)
        {
            Employee employee = null;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Employee Values({entity.EmpNo}, '{entity.EmpName}', {entity.Salary}, '{entity.Designation}', {entity.DeptNo}, '{entity.Email}')";
                int res = Cmd.ExecuteNonQuery(); //executes the sql query and returns number of rows affected
                if (res == 0)
                {
                    employee = null;
                }
                else
                {
                    employee = new Employee();
                    employee = entity;
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
            return employee;
        }
        Employee IDataAccessCrud<Employee, int>.Delete(int id)
        {
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd.CommandText = "Delete From Employee where EmpNo=@EmpNo";
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;
                Cmd.Parameters.Add(pEmpNo);
                int res = Cmd.ExecuteNonQuery();
                if (res == 0)
                {
                    employee = null;
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
            return employee;
        }
        IEnumerable<Employee> IDataAccessCrud<Employee, int>.GetAllData()
        {
            List<Employee> employee = new List<Employee>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Employee";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    employee.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              Email = Reader["Email"].ToString(),
                          }
                        );
                }
                Reader.Close();
                Conn.Close();
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
            return employee;
        }
       
        Employee IDataAccessCrud<Employee, int>.Update(int id, Employee entity)
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
                    int res = Cmd.ExecuteNonQuery();
                    if (res == 0)
                    {
                        employee = null;
                    }
                    else
                    {
                        employee = entity;
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
            return employee;
        }
    }
}
