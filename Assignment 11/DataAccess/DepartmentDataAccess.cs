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
    internal class DepartmentDataAccess : IDataAccess<Department,int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public DepartmentDataAccess()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }
        public async Task<IEnumerable<Department>> GetEmpDataAsync()
        {
            try
            {
                List<Department> depts = new List<Department>();
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Department";
                var deptData = await Cmd.ExecuteReaderAsync();
                //var r = EmpData;
                while (deptData.Read())
                {
                    depts.Add(new Department()
                    {
                        DeptNo = Convert.ToInt32(deptData["DeptNo"]),
                        DeptName = deptData["DeptName"].ToString(),
                        Capacity = Convert.ToInt32(deptData["Capacity"]),
                        Location = deptData["Location"].ToString(),
                       
                        
                    });
                }
                deptData.Close();
                Conn.Close();
                return Task.FromResult(depts).Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occured {ex.Message}");
                return null;
            }

        }

        public async Task Create(Department entity)
        {

            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Department Values({entity.DeptNo}, '{entity.DeptName}', '{entity.Location}', {entity.Capacity}  )";
                int res = await Cmd.ExecuteNonQueryAsync(); //executes the sql query and returns number of rows affected
                if (res == 0)
                {
                    Console.WriteLine("Department cannot be added\n");
                }
                else
                {
                    Console.WriteLine("Department added sucessfully");
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
            //  return employee;
        }

        public async Task Update(Department entity, int id)
        {
            Department dept = new Department();
            try
            {
                if (id == entity.DeptNo)
                {
                    Conn.Open();
                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Department Set  DeptName=@DeptName, Location=@Location, Capacity=@Capacity where DeptNo=@DeptNo";

                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;

                    pDeptNo.Value = id;

                    SqlParameter pDeptName = new SqlParameter();
                    pDeptName.ParameterName = "@DeptName";
                    pDeptName.SqlDbType = SqlDbType.VarChar;
                    pDeptName.Size = 200;
                    pDeptName.Direction = ParameterDirection.Input;
                    pDeptName.Value = entity.DeptName;

                    SqlParameter pLocation = new SqlParameter();
                    pLocation.ParameterName = "@Location";
                    pLocation.SqlDbType = SqlDbType.VarChar;
                    pLocation.Size = 100;
                    pLocation.Direction = ParameterDirection.Input;
                    pLocation.Value = entity.Location;

                    SqlParameter pCapacity = new SqlParameter();
                    pCapacity.ParameterName = "@Capacity";
                    pCapacity.SqlDbType = SqlDbType.Int;
                    pCapacity.Direction = ParameterDirection.Input;
                    pCapacity.Value = entity.Capacity;
        

                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pDeptName);
                    Cmd.Parameters.Add(pLocation);
                    Cmd.Parameters.Add(pCapacity);

                    int res = await Cmd.ExecuteNonQueryAsync();
                    if (res == 0)
                    {
                        Console.WriteLine("couldn't update department");
                    }
                    else
                    {
                        Console.WriteLine("department updated sucessfully");
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.DeptNo} does not match");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
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

        public async Task<int> Delete(int id)
        {
            Department dept = new Department();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete From Department where DeptNo=@DeptNo";
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;
                Cmd.Parameters.Add(pDeptNo);
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
    }
}
