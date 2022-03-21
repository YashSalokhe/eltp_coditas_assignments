using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var res = deptService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var res = deptService.CreateAsync(department).Result;
                return RedirectToAction("Index"); 
            }
            else
            {
                return View(department);
            }
        }
        /// <summary>
        /// the http get edit request must pass the route paramenter as 
        /// 'id' (Refer: app.UseEndpoint)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
