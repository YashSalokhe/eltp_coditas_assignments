using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;

namespace _16_March.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<UserInfo, int> userService;

        public UserController(IService<UserInfo, int>Service)
        {
          userService = Service;
        }
        public IActionResult Index()
        {
            var res = userService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var user = new UserInfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var res = userService.CreateAsync(user).Result;
                return RedirectToAction("Index"); 
            }
            else
            {
                return RedirectToAction("User");
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
            var res = userService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var res = userService.UpdateAsync(id, user).Result;
                return RedirectToAction("Index"); 
            }
             else
            {
                return RedirectToAction("Index");
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
            var res = userService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Delete(int id, UserInfo user)
        {
            var res = userService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}
