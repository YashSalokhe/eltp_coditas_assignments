using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace _16_March.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IService<Employee, int> empService;
        private readonly IService<Department, int> deptService;

        public EmployeeController(IService<Employee, int> Service , IService<Department, int> deptService)
        {
           // ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
            empService = Service;
            this.deptService = deptService;
        }

        public IActionResult Index()
        {
            var res = empService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var emp = new Employee();
            ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");

            //   emp.DeptNo = ViewBag.department.DeptNo;
         //   ViewBag.department;
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            //try
            //{

                var empNo = empService.GetAsync(employee.EmpNo);
                int capacity = deptService.GetAsync().Result.ToList().Where(x => x.DeptNo == employee.DeptNo).Select(x => x.Capacity).FirstOrDefault();
                int count = empService.GetAsync().Result.ToList().Where(x => x.DeptNo == employee.DeptNo).Count();
                if (empNo.Result != null)
                {
                        throw new Exception($"Employee No {employee.EmpNo} is already present");
                }
                if (ModelState.IsValid )
                {
                    
                    if (capacity > count)
                    {

                        var res = empService.CreateAsync(employee).Result;
                       
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                        ViewData["Message"] = "Cannot Add Employee";
                        ViewBag.NewMessage = "No More Space Is Available In Department";
                        return View(employee);
                    }

                }
                else
                {
                    ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                    ViewData["Message"] = "Wrong Data";
                    ViewBag.NewMessage = "Please enter proper data";
                    return View(employee);
                }
            //}
            //catch (Exception ex)
            //{

            //    return View("Error", new ErrorViewModel()
            //    {
            //        ControllerName = RouteData.Values["controller"].ToString(),
            //        ActionName = RouteData.Values["action"].ToString(),
            //        ErrorMessage = ex.Message
            //    });
            //}
        }
        /// <summary>
        /// the http get edit request must pass the route paramenter as 
        /// 'id' (Refer: app.UseEndpoint)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
            var res = empService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                var res = empService.UpdateAsync(id, employee).Result;
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewBag.department = new SelectList(deptService.GetAsync().Result.ToList(), "DeptNo", "DeptName");
                return RedirectToAction("Employee");
            }
        }
        /// <summary>
        /// Http Get reequest will accept an id of record to deltete and return a view that will 
        /// show the record to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var res = empService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Delete(int id, Employee employee)
        {
            var res = empService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var res = empService.GetAsync(id).Result;
          
            return View(res);
        }

        public IActionResult ValidateEmpName(string EmpName)
        {
            string[] words = EmpName.Split();
            int count = words.Length;

            
        
            if (count >2)
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: false);
            }
        }
    }
}
