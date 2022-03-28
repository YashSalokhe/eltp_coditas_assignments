using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace _16_March.Models
{
    public partial class Employee
    {
        [Required (ErrorMessage = "Enter employee number") ]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "Enter employee name")]
        [Remote(action: "ValidateEmpName", controller: "Employee", ErrorMessage = "EmpName is not in correct format")]
        [CheckString]
        public string EmpName { get; set; }
        [Required (ErrorMessage ="Enter salary")]
        [NonNegative]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Enter Designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Enter Dept number")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        public double Tax { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
