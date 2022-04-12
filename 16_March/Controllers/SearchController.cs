using _16_March.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace _16_March.Controllers
{
    public class SearchController : Controller
    {
        HttpClient client;
        public SearchController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            string name = HttpContext.Session.GetString("CatRowName");
            var cats = await client.GetFromJsonAsync<List<Product>>("https://localhost:7243/api/Search/" + name);
            return View(cats);
        }
        public IActionResult Search()
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Search(Category cat)
        {
            HttpContext.Session.SetString("CatRowName", cat.CategoryName);
            return RedirectToAction("Index");
        }


        
    }
}
