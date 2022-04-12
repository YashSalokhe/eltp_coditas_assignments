using Microsoft.AspNetCore.Mvc;
using _16_March.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace _16_March.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;
        public ProductController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var prod = await client.GetFromJsonAsync<List<Product>>("https://localhost:7243/api/Product");
            return View(prod);
        }
        public IActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var response = await client.PostAsJsonAsync<Product>("https://localhost:7243/api/Product", product);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(product);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            // var res = deptService.GetAsync(id).Result;
            var res = await client.GetFromJsonAsync<Product>("https://localhost:7243/api/Product/" + id);
            //var category=new Category();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var response = await client.PutAsJsonAsync<Product>("https://localhost:7243/api/Product/" + id, product);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(product);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            // var res = deptService.GetAsync(id).Result;
            var res = await client.GetFromJsonAsync<Product>("https://localhost:7243/api/Product/" + id);
            //var category=new Category();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Product product)
        {
            var response = await client.DeleteAsync("https://localhost:7243/api/Product/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(product);
            }
        }
    }
}
