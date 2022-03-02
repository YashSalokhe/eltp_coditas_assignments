using Assignment_9FW.Models;
using System;
using System.Collections.Generic;
using System.Data;  
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Assignment_9FW.DataAccess
{
    internal class DepartmentDataAccess : IDataAccess<Department>
    {
        SqlConnection Conn;
        public DepartmentDataAccess()
        {
            Conn = new SqlConnection("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
        }

        void IDataAccess<Department>.Delete()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataSet Ds = new DataSet();
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");

            Console.WriteLine("Enter Department number to delete");
            int no = int.Parse(Console.ReadLine());

            DataRow DrFind = Ds.Tables["Department"].Rows.Find(no);
            DrFind.Delete();
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
        }

        void IDataAccess<Department>.Insert()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataSet Ds = new DataSet();

            AdDept.Fill(Ds, "Department");
            DataRow DrNew = Ds.Tables["Department"].NewRow();

            Console.WriteLine("Enter Department No");
            int Deptno = int.Parse(Console.ReadLine());
            DrNew["DeptNo"] = Deptno;

            Console.WriteLine("Enter Department name");
            string Dname = Console.ReadLine();
            DrNew["DeptName"] = Dname;

            Console.WriteLine("Enter Location");
            string Location = Console.ReadLine();
            DrNew["Location"] = Location;

            Console.WriteLine("Enter Capacity");
            int cap = int.Parse(Console.ReadLine());
            DrNew["Capacity"] = cap;


            Ds.Tables["Department"].Rows.Add(DrNew);
            SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
        }

        void IDataAccess<Department>.Read()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataSet Ds = new DataSet();
            //AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");
            DataRowCollection dataRows = Ds.Tables["Department"].Rows;

            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["DeptNo"]}     {row["DeptName"]}       {row["location"]}       {row["Capacity"]}");
            }
        }

        void IDataAccess<Department>.Update()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataSet Ds = new DataSet();
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");
            Console.WriteLine("Enter Department number want to update");
            int no = int.Parse(Console.ReadLine());

            DataRow DrFind = Ds.Tables["Department"].Rows.Find(no);

            Console.WriteLine("Enter updated Department name");
            string Dname = Console.ReadLine();
            DrFind["DeptName"] = Dname;

            Console.WriteLine("Enter updated Location");
            string Location = Console.ReadLine();
            DrFind["Location"] = Location;

            Console.WriteLine("Enter updated Capacity");
            int cap = int.Parse(Console.ReadLine());
            DrFind["Capacity"] = cap;


            SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
        }
    }
}
