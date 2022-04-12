using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _16_March.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Department, int> deptService;
        /// <summary>
        /// Inject the IService<Department , int> aka department service in it
        /// </summary>
        public DepartmentController(IService<Department, int> service)
        {
            deptService = service;
        }

        //[Authorize(Roles = "Manager,Clerk,Operator")]
        [Authorize(Policy = "ReadPolicy")]
        public IActionResult Index()
        {
            var res = deptService.GetAsync().Result;
            return View(res);
        }

        //[Authorize(Roles = "Manager,Clerk")]
        [Authorize(Policy = "ManagerClerkPolicy")]
        public IActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                // USe if-else statements for Explict Model Validations
                var dept = deptService.GetAsync(department.DeptNo).Result;
                if (dept != null)
                {
                    throw new Exception($"Department No {department.DeptNo} is already present");
                }

                // if no error then Process values
                if (ModelState.IsValid)
                {
                    var res = deptService.CreateAsync(department).Result;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = "Kay Yaar again Wrong Data!!!!";
                    ViewBag.NewMessage = "Ram Bhala Kare";
                    //Stay on the same page
                    return View(department);
                }
            }
            catch (Exception ex)
            {
                // Return the Error Page
                //return View("Error", new ErrorViewModel() 
                //{
                //   ControllerName = "Department",
                //   ActionName = "Create",
                //   ErrorMessage = ex.Message
                //});

                return View("Error", new ErrorViewModel()
                {
                    ControllerName = RouteData.Values["controller"].ToString(),
                    ActionName = RouteData.Values["action"].ToString(),
                    ErrorMessage = ex.Message
                });

            }
        }
        /// <summary>
        /// the http get edit request must pass the route paramenter as 
        /// 'id' (Refer: app.UseEndpoint)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
 // [Authorize(Roles = "Manager,Clerk")]
        [Authorize(Policy = "ManagerClerkPolicy")]
        public IActionResult Edit(int id)
        {
            var res = deptService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var res = deptService.UpdateAsync(id, department).Result;
                return RedirectToAction("Index"); 
            }
            else
            {
                return RedirectToAction("Department");
            }
        }
        /// <summary>
        /// Http Get reequest will accept an id of record to deltete and return a view that will 
        /// show the record to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
         // [Authorize(Roles = "Manager")]
        [Authorize(Policy = "ManagerPolicy")]
        public IActionResult Delete(int id)
        {
           // var res = deptService.GetAsync(id).Result;
            var resdel = deptService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Delete(int id, Department department)
        //{
        //    var res = deptService.DeleteAsync(id).Result;
        //    return RedirectToAction("Index");
        //}
    }
}
