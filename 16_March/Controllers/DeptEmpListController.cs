using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace _16_March.Controllers
{
    public class DeptEmpListController : Controller
    {
        private readonly IService<Department, int> deptServ;
        private readonly IService<Employee, int> empServ;
        public DeptEmpListController(IService<Department, int> deptServ, IService<Employee, int> empServ)
        {
            this.deptServ = deptServ;
            this.empServ = empServ;
        }
        public IActionResult Index(int id = 0)
        {
            var deptEmps = new DeptEmpLists();
            deptEmps.Departments = deptServ.GetAsync().Result.ToList();
            deptEmps.Employees = empServ.GetAsync().Result.ToList();
            List<EmpData> employee = new List<EmpData>();

            //foreach(var emp in deptEmps.Employees)
            //{
            //    employee.Add(new EmpData { DeptNo = }
            //}
            if (id == 0)
            {
                ViewBag.department = new SelectList(deptServ.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                deptEmps.Employees = empServ.GetAsync().Result.ToList();

                
            }
            else
            {
                ViewBag.department = new SelectList(deptServ.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                deptEmps.Employees = empServ.GetAsync().Result.Where(e => e.DeptNo == id).ToList();
            }

            return View(deptEmps);
        }

        public IActionResult ShowEmps(DeptEmpLists dept )
        {
            int deptNo = dept.DeptNo;
            // return to Index View with a Route Parameter
            return RedirectToAction("Index", new { id = deptNo });
        }
    }
}
