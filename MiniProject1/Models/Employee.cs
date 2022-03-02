﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1.Models
{
    /// <summary>
    /// Data Class to Store Employee Information
    /// </summary>
    internal class Employee
    {
        private int _EmpNo;
        public int EmpNo
        {
            get { return _EmpNo; } 
            set { _EmpNo = value; } 
            //set 
            //{
            //    try
            //    {
            //        if (value > 0)
            //        { _EmpNo = value; }
            //        else
            //        {
            //            throw new Exception("cannot be negative\n");
            //        }
            //    } // write
                
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error Occured {ex.Message}");
            //    }
            //    }
        }
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; } // return value
            set { _EmpName = value; } // accept value
        }
        private string _DeptName;
        public string DeptName
        {   
            get { return _DeptName; }
            set
            {
                //if (value == "IT" || value == "HRD" || value == "Sales" || value == "Admin" || value == "Account")
                //{
                //    _DeptName = value;
                //}
                _DeptName = value;

            }
        }
        private string _Designation;
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }
        private int _Salary;
        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
    }
}