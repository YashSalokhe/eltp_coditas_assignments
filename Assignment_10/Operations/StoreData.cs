    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Assignment_10.Models;

namespace Assignment_10.Operations
{
    internal class StoreData
    {
        SqlConnection Conn;
        string filepath = string.Empty;
        public StoreData()
        {
            filepath = $"C:\\Users\\Coditas\\source\\repos\\ELTP_DotNET\\Assignment_10\\FileStore\\Employeedata.txt";
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }

        public void WriteDataToFile(Employee employee)
        {

            try
            {
                byte[] content = new UTF8Encoding(true).GetBytes($"\n{employee.EmpNo}\t {employee.EmpName}\t  {employee.Salary}\t {employee.Designation}\t {employee.DeptNo}\t{employee.Email}");
                FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write);
                
                fs.Write(content, 0, content.Length);
                fs.Close();
                Console.WriteLine("Data saved successfully to file");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error occured - {ex.Message}");
            }


        }

        public void WriteDataToDB(Employee employee)
        {
            try
            {
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
                DataSet Ds = new DataSet();

                AdEmp.Fill(Ds, "Employee");
                DataRow DrNew = Ds.Tables["Employee"].NewRow();
                DrNew["EmpNo"] = employee.EmpNo;
                DrNew["EmpName"] = employee.EmpName;
                DrNew["Salary"] = employee.Salary;
                DrNew["DeptNo"] = employee.DeptNo;
                DrNew["Designation"] = employee.Designation;
                DrNew["Email"] = employee.Email;
                Ds.Tables["Employee"].Rows.Add(DrNew);
                SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdEmp);
                AdEmp.Update(Ds, "Employee");
                Console.WriteLine("Data Added to database successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"error occured - {ex.Message}");
                
            }

        }

        public Employee GetData()
        {
            Console.WriteLine("Enter Employee No");
            int Empno = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter Employee name");
            string name = Console.ReadLine();


            Console.WriteLine("Enter Salary");
            int Salary = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter Dept number");
            int DeptNo = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter Designation");
            string Designation = Console.ReadLine();



            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();

            Employee employee = new Employee()
            {
                EmpNo = Empno,
                EmpName = name,
                Salary = Salary,
                DeptNo = DeptNo,
                Designation = Designation,
                Email = Email
            };
            return employee;
        }

        public void readFromDataBase()
        {
            SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
            DataSet Ds = new DataSet();
            AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdEmp.Fill(Ds, "Employee");
            DataRowCollection dataRows = Ds.Tables["Employee"].Rows;

            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["EmpNo"]}     {row["EmpName"]}    {row["DeptNo"]}  {row["Designation"]}       {row["Salary"]}  {row["Email"]} ");
            }
        }

        public void readFromFile()
        {
            string contents = String.Empty;
            contents = File.ReadAllText(filepath);

            Console.WriteLine($"{ contents}");
            
        }
    }
}
