using Microsoft.AspNetCore.Mvc;
using _16_March.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace _16_March.Controllers 
{
    public class CategoryController : Controller
    {
        HttpClient client;
        public CategoryController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var cats = await client.GetFromJsonAsync<List<Category>>("https://localhost:7243/api/Category");
            return View(cats);
        }
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var response = await client.PostAsJsonAsync<Category>("https://localhost:7243/api/Category", category);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            // var res = deptService.GetAsync(id).Result;
            var res = await client.GetFromJsonAsync<Category>("https://localhost:7243/api/Category/" + id);
            //var category=new Category();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            var response = await client.PutAsJsonAsync<Category>("https://localhost:7243/api/Category/" + id, category);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }
        public async Task<IActionResult> Delete(int id )
        {
            // var res = deptService.GetAsync(id).Result;
            var res = await client.GetFromJsonAsync<Category>("https://localhost:7243/api/Category/" + id);
            //var category=new Category();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Category category)
        {
            var response = await client.DeleteAsync("https://localhost:7243/api/Category/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }

    }
}
