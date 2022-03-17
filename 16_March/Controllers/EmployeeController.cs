using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;

namespace _16_March.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IService<Employee, int> empService;

        public EmployeeController(IService<Employee, int> Service)
        {
            empService = Service;
        }
        public IActionResult Index()
        {
            var res = empService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var res = empService.CreateAsync(employee).Result;
            return RedirectToAction("Index");
        }
        /// <summary>
        /// the http get edit request must pass the route paramenter as 
        /// 'id' (Refer: app.UseEndpoint)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var res = empService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            var res = empService.UpdateAsync(id, employee).Result;
            return RedirectToAction("Index");
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
    }
}
